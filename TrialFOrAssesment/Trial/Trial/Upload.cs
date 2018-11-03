using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace Trial
{
    public class FileHelper
    {
        static string CurrentFolderPath = ""; 
        public static void UploadDocument(ClientContext clientContext, string sourceFilePath, string serverRelativeDestinationPath)
        {
            try
            {
                using (var fs = new FileStream(sourceFilePath, FileMode.Open))
                {
                    var fi = new FileInfo(sourceFilePath);
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, serverRelativeDestinationPath, fs, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void UploadFolder(ClientContext clientContext, System.IO.DirectoryInfo folderInfo, Folder folder)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            try
            {
                files = folderInfo.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    Console.WriteLine(fi.FullName);
                    clientContext.Load(folder);
                    clientContext.ExecuteQuery();
                    UploadDocument(clientContext, fi.FullName, folder.ServerRelativeUrl + "/" + fi.Name);
                }

                subDirs = folderInfo.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    Folder subFolder = folder.Folders.Add(dirInfo.Name);

                    clientContext.ExecuteQuery();
                    UploadFolder(clientContext, dirInfo, subFolder);
                }
            }
        }

        public static void UploadFoldersRecursively(ClientContext clientContext, string sourceFolder, string destinationLigraryTitle)
        {
            Web web = clientContext.Web;
            var query = clientContext.LoadQuery(web.Lists.Where(p => p.Title == destinationLigraryTitle));

            clientContext.ExecuteQuery();
            List documentsLibrary = query.FirstOrDefault();
            var folder = documentsLibrary.RootFolder;
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(sourceFolder);

            clientContext.Load(documentsLibrary.RootFolder);
            clientContext.ExecuteQuery();
            folder = documentsLibrary.RootFolder.Folders.Add(di.Name);


            clientContext.ExecuteQuery();

            FileHelper.UploadFolder(clientContext, di, folder);
        }
        public static void CreateFolder(ClientContext clientContext, string path, string destinationLigraryTitle)
        {
            string[] splitpath = path.Split(Convert.ToChar(92));


            Console.WriteLine(splitpath[1]);
            Web web = clientContext.Web;
            var query = clientContext.LoadQuery(web.Lists.Where(p => p.Title == destinationLigraryTitle));
            clientContext.ExecuteQuery();
            List documentsLibrary = query.FirstOrDefault();
            clientContext.Load(documentsLibrary.RootFolder);
            var folder = documentsLibrary.RootFolder;
            clientContext.ExecuteQuery();
            folder = documentsLibrary.RootFolder.Folders.Add(splitpath[1]);
            clientContext.ExecuteQuery();
            if (splitpath.Length >= 2)
            {
                CreateSubFolder(clientContext, path, 2, splitpath, folder);
            }
            else
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);
                UploadFolder(clientContext, di, folder);
            }

        }
        public static void CreateSubFolder(ClientContext clientContext,string path,int i ,string []SubFolder, Folder folder)
        {
            int cnt = i;
            cnt++;
            Folder subFolder = folder.Folders.Add(SubFolder[i]);
            clientContext.ExecuteQuery();
             if (cnt < SubFolder.Length)
            {
                  
                CreateSubFolder(clientContext, path,cnt, SubFolder, subFolder);
            }
            else
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);
                UploadFolder(clientContext,di, subFolder);
            }
        }

    }
}
