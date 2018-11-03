using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Microsoft.SharePoint.Client;
using System.IO;

namespace UploadFolder
{
    class SPUploadFolder
    {


        public static string FolderpathForPermission="";

        //___________________________upload doccument in respective Folder in Document Library_____________________//
        public static void UploadDocument(ClientContext clientContext, string sourceFilePath, string serverRelativeDestinationPath)
        {
            try
            {
                using (var FileStream = new FileStream(sourceFilePath, FileMode.Open))
                {
                    var fileInfo = new FileInfo(sourceFilePath);
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, serverRelativeDestinationPath, FileStream, true);
                }
            }
            catch (Exception ex)
            {
                //error file
            }
        }

        //_____________________Add files and add subfolders in document library_____________________________//
        public static void UploadFolder(ClientContext clientContext, System.IO.DirectoryInfo folderInfo, Folder folder, string destinationLigraryTitle)
        {
            System.IO.FileInfo[] Files = null;
            System.IO.DirectoryInfo[] SubDirs = null;

            try
            {
                Files = folderInfo.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                //error file
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                //error file
            }
            if (Files != null)
            {
                foreach (System.IO.FileInfo fileInfo in Files)
                {
                    Console.WriteLine(fileInfo.FullName);
                    clientContext.Load(folder);
                    clientContext.ExecuteQuery();
                    UploadDocument(clientContext, fileInfo.FullName, folder.ServerRelativeUrl + "/" + fileInfo.Name);
                }
                SubDirs = folderInfo.GetDirectories();
                foreach (System.IO.DirectoryInfo DirectoriInfo in SubDirs)
                {
                    Folder subFolder = folder.Folders.Add(DirectoriInfo.Name);
                    //________________give permissions to added folder in document libray______________// 
                    Permissions.GetPermmssion(clientContext, subFolder, Path.GetFullPath(DirectoriInfo.ToString()), destinationLigraryTitle);
                    clientContext.ExecuteQuery();
                    UploadFolder(clientContext, DirectoriInfo, subFolder, destinationLigraryTitle);
                }
            }
        }

        //________________________add folder in doccument library if rootfolder path have one folder _________________//

        public static void UploadFoldersRecursively(ClientContext clientContext, string sourceFolder, string destinationLigraryTitle)
        {
            try
            {
                Web web = clientContext.Web;
                var Query = clientContext.LoadQuery(web.Lists.Where(p => p.Title == destinationLigraryTitle));
                clientContext.ExecuteQuery();
                List documentsLibrary = Query.FirstOrDefault();
                var folder = documentsLibrary.RootFolder;
                System.IO.DirectoryInfo DirectoriInfo = new System.IO.DirectoryInfo(sourceFolder);
                clientContext.Load(documentsLibrary.RootFolder);
                clientContext.ExecuteQuery();
                folder = documentsLibrary.RootFolder.Folders.Add(DirectoriInfo.Name);

                //________________give permissions to added folder in document libray______________// 
                Permissions.GetPermmssion(clientContext, folder, sourceFolder, destinationLigraryTitle);
                clientContext.ExecuteQuery();
                SPUploadFolder.UploadFolder(clientContext, DirectoriInfo, folder, destinationLigraryTitle);
            }
            catch (Exception ex)
            {
                //error file
            }
        }

        //________________________add folder in doccument library if rootfolder path have more than one folder _________________//
        public static void CreateFolder(ClientContext clientContext, string path, string destinationLigraryTitle)
        {
            try
            {
                string[] Splitpath = path.Split(Convert.ToChar(92));
                Web web = clientContext.Web;
                var query = clientContext.LoadQuery(web.Lists.Where(p => p.Title == destinationLigraryTitle));
                clientContext.ExecuteQuery();
                List DocumentsLibrary = query.FirstOrDefault();
                clientContext.Load(DocumentsLibrary.RootFolder);
                var folder = DocumentsLibrary.RootFolder;
                clientContext.ExecuteQuery();
                folder = DocumentsLibrary.RootFolder.Folders.Add(Splitpath[1]);
                clientContext.ExecuteQuery();
                FolderpathForPermission += Splitpath[0] + "\\" + Splitpath[1];

                //________________give permissions to added folder in document libray______________// 
                Permissions.GetPermmssion(clientContext, folder, FolderpathForPermission, destinationLigraryTitle);
                if (Splitpath.Length >= 2)
                {
                    CreateSubFolder(clientContext, path, 2, Splitpath, folder, destinationLigraryTitle);
                }
                else
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);
                    UploadFolder(clientContext, di, folder, destinationLigraryTitle);
                }
            }
            catch (Exception ex)
            {
                //error file
            }
        }

        //________________________add Subfolder in doccument library if rootfolder path have more than one folder _________________//
        public static void CreateSubFolder(ClientContext clientContext, string path, int i, string[] SubFolder, Folder folder, string destinationLigraryTitle)
        {
            int cnt = i;
            cnt++;
            try
            {
                Folder subFolder = folder.Folders.Add(SubFolder[i]);
                clientContext.ExecuteQuery();
                FolderpathForPermission += "\\" + SubFolder[i];

                //________________give permissions to added folder in document libray______________// 
                Permissions.GetPermmssion(clientContext, folder, FolderpathForPermission, destinationLigraryTitle);
                if (cnt < SubFolder.Length)
                {
                    CreateSubFolder(clientContext, path, cnt, SubFolder, subFolder, destinationLigraryTitle);
                }
                else
                {
                    System.IO.DirectoryInfo DirectoriInfo = new System.IO.DirectoryInfo(path);

                    //if 
                    UploadFolder(clientContext, DirectoriInfo, subFolder, destinationLigraryTitle);
                }
            }
            catch (Exception ex)
            {
                //error file
            }
        }


    }
}
