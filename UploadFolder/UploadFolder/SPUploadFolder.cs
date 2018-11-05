using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using DAL;
using DAL.Repository;
using System.Data;

namespace UploadFolder
{
    class SPUploadFolder
    {
        public string FolderPAthForPermission = "";
        Permissions SpPermissions = new Permissions();

        SPFolderUploadRepository SPFolderUploadRepositoryObj = new SPFolderUploadRepository();
        DataTable GetSubFoldersTable;
        DataTable GetFilesInfo;


        //***********************************Upload Doccument From the directory******************************// 
        public void UploadDocument(ClientContext clientContext, string sourceFilePath, string serverRelativeDestinationPath)
        {

            string UploadStatus;
            UploadLog UploadTimeLog = new UploadLog();
            DateTime StartTime = DateTime.Now;
            if ((GetFilesInfo.Rows.Count != 0) && (GetFilesInfo.Select("Path='" + sourceFilePath.ToString() + "'").Length > 0))
            {
                try
                {
                    using (var FileStream = new FileStream(sourceFilePath, FileMode.Open))
                    {
                        var fileInfo = new FileInfo(sourceFilePath);
                        Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, serverRelativeDestinationPath, FileStream, true);
                        UploadStatus = "Success";
                    }
                }
                catch (Exception ex)
                {
                    UploadStatus = "Failure";
                    ErrrorLog.ErrorlogWrite(ex);
                }
               
            }
            else
            {
                UploadStatus = "File is not Supported Or Fil path is not ok";
            }
            DateTime EndTime = DateTime.Now;
            UploadTimeLog.UploadTimeWrite(sourceFilePath.Split('/').Last(), sourceFilePath, UploadStatus, StartTime, EndTime);
        }

        //*********************************** add subfolder in doccument library and create SubFolder From the directory******************************// 

        public void UploadFolder(ClientContext clientContext, System.IO.DirectoryInfo folderInfo, Folder folder)
        {
            System.IO.FileInfo[] Files = null;
            System.IO.DirectoryInfo[] SubDirs = null;

            try
            {
                Files = folderInfo.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
            }
            if (Files != null)
            {
                int SubFolderId = 0;
                DataRow[] DatarowObj = GetSubFoldersTable.Select("Path='" + folderInfo.FullName.ToString() + "'");
                if (DatarowObj.Length != 0)
                {
                    SubFolderId = Convert.ToInt32(DatarowObj[0][0]);
                }
                if (SubFolderId > 0)
                {
                    GetFilesInfo = SPFolderUploadRepositoryObj.GetFileInformation(SubFolderId);
                }

                foreach (System.IO.FileInfo Fi in Files)
                {

                    //Console.WriteLine(Fi.FullName);
                    clientContext.Load(folder);
                    clientContext.ExecuteQuery();
                    UploadDocument(clientContext, Fi.FullName, folder.ServerRelativeUrl + "/" + Fi.Name);
                }

                SubDirs = folderInfo.GetDirectories();

                foreach (System.IO.DirectoryInfo DirectoriInfo in SubDirs)
                {
                    if ((GetSubFoldersTable.Rows.Count != 0) && (GetSubFoldersTable.Select("Path='" + DirectoriInfo.FullName.ToString() + "'").Length > 0))
                    {
                        Folder subFolder = folder.Folders.Add(DirectoriInfo.Name);
                        clientContext.ExecuteQuery();
                        try
                        {
                            //_______________Add Permissions for the folder______________________//
                            SpPermissions.GetPermmssion(clientContext, subFolder, DirectoriInfo.FullName);
                        }
                        catch (Exception ex)
                        {
                            ErrrorLog.ErrorlogWrite(ex);
                        }
                        UploadFolder(clientContext, DirectoriInfo, subFolder);
                    }
                }
            }

        }

        //***********************************add  folder in doccument library if rootfolder path  have one folder ******************************// 

        public void UploadFoldersRecursively(ClientContext clientContext, string RootFolderName, string destinationLigraryTitle, int RootFolderId)
        {
          
            try
            {
                Web Webobj = clientContext.Web;
                var query = clientContext.LoadQuery(Webobj.Lists.Where(GetTitle => GetTitle.Title == destinationLigraryTitle));
                clientContext.ExecuteQuery();
                List DocumentsLibrary = query.FirstOrDefault();
                var Folder = DocumentsLibrary.RootFolder;

                clientContext.Load(DocumentsLibrary.RootFolder);
                clientContext.ExecuteQuery();
                Folder = DocumentsLibrary.RootFolder.Folders.Add(RootFolderName);
                clientContext.ExecuteQuery();

                string RootFolderPath = SPFolderUploadRepositoryObj.RootFolderPath(RootFolderId);  //Get Root Folder Path to get Directory Info
                 GetSubFoldersTable = SPFolderUploadRepositoryObj.GetSubFolderData(RootFolderId);  //Fills Datatable with Subfolder Table
                System.IO.DirectoryInfo DirectoriInfo = new System.IO.DirectoryInfo(RootFolderPath);
                UploadFolder(clientContext, DirectoriInfo, Folder);   
                //try
                //{
                //    //_______________Add Permissions for the folder______________________//
                //    SpPermissions.GetPermmssion(clientContext, Folder, FolderPAthForPermission);
                //}
                //catch (Exception ex)
                //{
                //    ErrrorLog.ErrorlogWrite(ex);

                //}
                //if (Splitpath.Length >2)
                //{
                //    CreateSubFolder(clientContext, RootFolderName, 2, Splitpath, Folder);
                //}
                //else
                //{
                //    System.IO.DirectoryInfo DirectoriInfo = new System.IO.DirectoryInfo(RootFolderName);
                //    UploadFolder(clientContext, DirectoriInfo, Folder);
                //}

            }
            catch (Exception ex)
                {
                ErrrorLog.ErrorlogWrite(ex);
            }
        }


        //***********************************add Subfolders in document library if rootfolder path has more than more than one folder******************************// 

        public void CreateSubFolder(ClientContext clientContext, string path, int folderLocationCount, string[] SubFolder, Folder folder)
        {

            int FolderLocationcnt = folderLocationCount;
            FolderLocationcnt++;
            try
            {
                Folder subFolder = folder.Folders.Add(SubFolder[folderLocationCount]);
                clientContext.ExecuteQuery();
                FolderPAthForPermission += "\\" + SubFolder[folderLocationCount];
                try
                {
                    //_______________Add Permissions for the folder______________________//
                    SpPermissions.GetPermmssion(clientContext, folder, FolderPAthForPermission);
                }
                catch (Exception ex)
                {
                    ErrrorLog.ErrorlogWrite(ex);
                }
                if (FolderLocationcnt < SubFolder.Length)
                {
                    CreateSubFolder(clientContext, path, FolderLocationcnt, SubFolder, subFolder);
                }
                else
                {
                    System.IO.DirectoryInfo DirectoriInfo = new System.IO.DirectoryInfo(path);
                    UploadFolder(clientContext, DirectoriInfo, subFolder);
                }
            }
            catch (Exception ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
            }
        }

    }
}

