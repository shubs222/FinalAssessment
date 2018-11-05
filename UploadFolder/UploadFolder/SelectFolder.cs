
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.Repository;

namespace UploadFolder
{
    class SelectFolder
    {
        IList<string> RootFoldersPath = new List<string>();  // list for RootFoldersPath
        IList<string> SubFoldersPath = new List<string>();   // list for SubFoldersPath
        public void GetSubDirectories(String RootFolderPath, int RootFolderId) //Retriving the sub folders and files 
        {
            FileInformation Dbcall = new FileInformation();
            string[] SubdirectoryEntries = Directory.GetDirectories(RootFolderPath); //Identifying and retriving the all sub folders 
            string[] AllFilesinDirectory = Directory.GetFiles(RootFolderPath);//Identifying and retriving the all sub files 
            if (AllFilesinDirectory.Length > 0) //checking the root folders is contains the files or not
            {
                SubFoldersPath.Add(RootFolderPath);
                SubFolder FolderDetails = GetFolderdetails(RootFolderPath); //Retriving the folder information 
                int PresentFolderID = Dbcall.UploadSubFolder(FolderDetails, RootFolderId); //upload into the database
                foreach (String FilePath in AllFilesinDirectory)
                {
                    try
                    {
                        DAL.Model.FileInfo FileInfo = GetFileInfo(FilePath);//Retriving the file information 
                        //System.IO.FileInfo pdfFiles = AllFilesinDirectory.GetFIl
                        Dbcall.UploadFile(FileInfo, PresentFolderID);//upload into the database
                    }
                    catch (Exception ex)
                    {
                        ErrrorLog.ErrorlogWrite(ex);
                    }
                }
            }
            foreach (string subdirectory in SubdirectoryEntries)
            {
                try
                {
                    SubFolder FolderDetails = GetFolderdetails(subdirectory);
                    int FolderID = Dbcall.UploadSubFolder(FolderDetails, RootFolderId);//upload into the database
                    LoadSubDirs(subdirectory, FolderID, RootFolderId);  //getting information of the sub folders 
                }
                catch (Exception Ex)
                {
                    ErrrorLog.ErrorlogWrite(Ex);
                }
            }

        }
        private void LoadSubDirs(string directory, int PresentFolderid, int Rootid)
        {
            FileInformation Sub = new FileInformation();
            SubFoldersPath.Add(directory);
            string[] SubdirectoryEntries = Directory.GetDirectories(directory);//Identifying and retriving the all sub folders 
            string[] AllFilesinDirectory = Directory.GetFiles(directory);//Identifying and retriving the all sub files 
            foreach (String FilePath in AllFilesinDirectory) // we have all file. now getting file info and upload it into database
            {
                try
                {
                    DAL.Model.FileInfo fileInfo = GetFileInfo(FilePath); //getting File info
                    Sub.UploadFile(fileInfo, PresentFolderid);//upload the file into database
                }
                catch (Exception Ex)
                {
                    ErrrorLog.ErrorlogWrite(Ex);
                }
            }
            foreach (string subdirectory in SubdirectoryEntries) //all subfolders
            {
                try
                {
                    SubFolder FolderDetails = GetFolderdetails(subdirectory); //getting sub folder details 
                    int FolderID = Sub.UploadSubFolder(FolderDetails, Rootid); //upload the sub folder into datatbase and that return id after insert 
                    LoadSubDirs(subdirectory, FolderID, Rootid); //the id is used for uploading file
                }
                catch (Exception Ex)
                {
                    ErrrorLog.ErrorlogWrite(Ex);
                }
            }
        }
        private SubFolder GetFolderdetails(string directoryPath) // getting sub Folder details 
        {
            SubFolder Folder = new SubFolder();
            try
            {
                DirectoryInfo DirectoryInfo = new DirectoryInfo(directoryPath);
                int LastIndexOf = directoryPath.LastIndexOf("\\");
                String FolderName = directoryPath.Substring(LastIndexOf + 1);


                if (FolderName.Length > 128) //here checking the folder name length
                {
                    throw new Exception(string.Format("Folder name is above 128 characters"));
                }
                else
                {
                    char[] GetInvalidCharacters = Path.GetInvalidFileNameChars(); //getting all invalid characters 
                    if (FolderName.Length - FolderName.Replace(".", "").Length <= 1) //checking the file has more than two dots
                    {
                        foreach (char OneCharacter in GetInvalidCharacters) //checking the each character in file name
                        {
                            if (FolderName.Contains(OneCharacter))
                            {
                                throw new Exception(string.Format("Folder name can't contains \"*:<>?//\\|. "));
                            }
                        }
                        Folder.Name = FolderName;
                    }
                    else
                    {
                        throw new Exception(string.Format("Folder name can't contains \"*:<>?//\\|. "));
                    }
                }
                if (directoryPath.Length > 260) //checking the file path length
                {
                    throw new Exception(string.Format("Folder path can't more than 260 characters"));
                }
                else
                    Folder.Path = directoryPath;
                string OwnerOfFolder = System.IO.File.GetAccessControl(directoryPath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();

                Folder.Path = directoryPath;
                Folder.CreatedOn = DirectoryInfo.CreationTime;
                Folder.ModifiedOn = DirectoryInfo.LastAccessTime;
                Folder.ModifiedBy = OwnerOfFolder;
                Folder.CreatedBy = OwnerOfFolder;
            }
            catch (Exception Ex)
            {
                ErrrorLog.ErrorlogWrite(Ex);
            }
            return Folder;
        }
        public RootFolder GetRootFolderdetails(string directoryPath)  // getting root Folder details

        {
            RootFolder Folder = new RootFolder();
            try
            {
                DirectoryInfo DirectoryInfo = new DirectoryInfo(directoryPath);
                int LastIndexOf = directoryPath.LastIndexOf("\\");
                String FolderName = directoryPath.Substring(LastIndexOf + 1);


                if (FolderName.Length > 128)//here checking the folder name length
                {
                    throw new Exception(string.Format("Folder name is above 128 characters"));
                }
                else
                {
                    char[] GetInvalidCharacters = Path.GetInvalidFileNameChars();//getting all invalid characters
                    if (FolderName.Length - FolderName.Replace(".", "").Length <= 1) //checking the file has more than two dots
                    {

                        foreach (char OneCharacter in GetInvalidCharacters)//checking the each character in file name
                        {
                            if (FolderName.Contains(OneCharacter))
                            {
                                throw new Exception(string.Format("Folder name can't contains \"*:<>?//\\|. "));
                            }
                        }
                        Folder.Name = FolderName;
                    }
                    else
                    {
                        throw new Exception(string.Format("Folder name can't contains \"*:<>?//\\|. "));
                    }
                }
                if (directoryPath.Length > 260)//checking the file path length
                {
                    throw new Exception(string.Format("Folder path can't more than 260 characters"));
                }
                else
                    Folder.Path = directoryPath;
                string user = System.IO.File.GetAccessControl(directoryPath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();//Used to retriving the owner 
                Folder.CreatedOn = DirectoryInfo.CreationTime;
                Folder.ModifiedOn = DirectoryInfo.LastAccessTime;
                Folder.ModifiedBy = user;
                Folder.CreatedBy = user;
            }
            catch (Exception Ex)
            {
                ErrrorLog.ErrorlogWrite(Ex);
            }
            return Folder;
        }
        public DAL.Model.FileInfo GetFileInfo(string FilePath) //getting file details 
        {
            DAL.Model.FileInfo Filedetails = new DAL.Model.FileInfo();
            try
            {

                System.IO.FileInfo File = new System.IO.FileInfo(FilePath);
                if (File.Name.Length > 128)
                {
                    throw new Exception(string.Format("File name is above 128 characters"));
                }
                else
                {
                    char[] GetInvalidCharacters = Path.GetInvalidFileNameChars();
                    if (File.Name.Length - File.Name.Replace(".", "").Length <= 1)
                    {
                        Filedetails.Name = File.Name;
                        foreach (char Charactor in GetInvalidCharacters)
                        {
                            if (File.Name.Contains(Charactor))
                            {
                                throw new Exception(string.Format("File name can't contains \"*:<>?//\\|. "));
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("File name can't contains \"*:<>?//\\|. "));
                    }
                }
                if (File.DirectoryName.Length > 260)
                {
                    throw new Exception(string.Format("File path can't more than 260 characters"));
                }
                else
                Filedetails.Path = FilePath;
                Filedetails.Type = File.Extension;
                float lengthbytes = (File.Length / 1024f) / 1024f;
                double length = Math.Round(((File.Length / 1024f) / 1024f), 4, MidpointRounding.AwayFromZero);
                Filedetails.Size = Convert.ToString(length);
                Filedetails.Size = Filedetails.Size + " MB";
                Filedetails.CreatedOn = File.CreationTime;
                Filedetails.FileAccessed = File.LastAccessTime;
                Filedetails.IsFilePathOK = true;
                Filedetails.IsFilesupported = true;
                Filedetails.ModifiedOn = File.LastWriteTime;
                Filedetails.CreatedBy = System.IO.File.GetAccessControl(FilePath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                Filedetails.ModifiedBy = System.IO.File.GetAccessControl(FilePath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
            }
            catch (Exception Ex)
            {
                ErrrorLog.ErrorlogWrite(Ex);
            }
            return Filedetails;
        }
    }
}
