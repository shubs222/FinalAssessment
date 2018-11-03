using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using System.Security;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using DAL;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Trial
{
    class Program
    {

        //static SecureString str = GetPassword();
        static string constring = "Data Source = ACUPC_113; Initial Catalog = FolderUpload; Integrated Security = True";
        static ClientContext context = new ClientContext("https://acuvatehyd.sharepoint.com/teams/shubhamtrial");
        static DataSet ds = new DataSet();
        static string path = "";
        static void Main(string[] args)
        {
            //List<string> folderNames = new List<string>();
            //UploadDataRepository uploadData = new UploadDataRepository();
            //context.Credentials = new SharePointOnlineCredentials("arvind.torvi@acuvate.com", str);
            //deleteSharedWithEveryoneFolder();
            //List list = context.Web.Lists.GetByTitle("Documents");
            //var folder = list.RootFolder;
            //Web web = context.Web;
            //context.Load(web);
            //context.ExecuteQuery();
            //context.Load(folder);
            //context.ExecuteQuery();
            //EventChannelGetData();
            //DataTable dt1 = ds.Tables["RootFolder"];
            //DataTable dt2 = ds.Tables["SubFolder"];
            //DataTable dt3 = ds.Tables["FileInfo"];


            //foreach (DataRow row in dt1.Rows)
            //{
            //    ListItemCreationInformation newItemInfo = new ListItemCreationInformation();
            //    newItemInfo.UnderlyingObjectType = FileSystemObjectType.Folder;
            //    newItemInfo.LeafName = row["Name"].ToString();
            //    ListItem newListItem = list.AddItem(newItemInfo);
            //    newListItem["Title"] = row["Name"].ToString();
            //    newListItem.Update();
            //}
            //context.ExecuteQuery();
            //foreach (DataRow dt1row in dt1.Rows)
            //{
            //    GetSUbFolderTable(dt1row["Id"].ToString());
            //    foreach (DataRow dt2row in dt2.Rows)
            //    {
            //        string dt2rowPath = dt2row["path"].ToString().Split(Convert.ToChar(92)).Last();
            //        string folderUrl = context.Web.ServerRelativeUrl + "/Shared Documents/" + dt1row["Name"].ToString();
            //        if (!(dt1row["Name"].ToString() == dt2rowPath))
            //        {
            //            var folderToAdd = context.Web.GetFolderByServerRelativeUrl(folderUrl);
            //            folderToAdd.AddSubFolder(dt2row["Name"].ToString());
            //            context.ExecuteQuery();
            //            //ListItemCreationInformation newItemInfo = new ListItemCreationInformation();
            //            //newItemInfo.UnderlyingObjectType = FileSystemObjectType.Folder;
            //            //newItemInfo.LeafName = dt2row["Name"].ToString();
            //            //ListItem newListItem = list.AddItem(newItemInfo);
            //            //newListItem["Title"] = dt2row["Name"].ToString();
            //            //newListItem.Update();
            //        }
            //    }
            //}
            //string path = @"D:\Folder1\Folder2";

            //string[] splitpath = path.Split(Convert.ToChar(92));
            //if (splitpath.Length > 2)
            //{
            //    FileHelper.CreateFolder(context, path, "Documents");
            //}
            //else
            //{

            //    FileHelper.UploadFoldersRecursively(context, path, "Documents");
            //}
            ////FileHelper.UploadFoldersRecursively(context, path,"Documents");
            //for (int i = 1; i < splitpath.Length - 1; i++)
            //{
            //    Console.WriteLine(splitpath[i]);

            //}
            //WindowsIdentity identity = WindowsIdentity.GetAnonymous();
            //Console.WriteLine(identity);
            //Console.ReadKey();
            //string path = @"D:\My Tasks\FinalAssessment\UploadFolder";
            //string NtAccountName = @"ACUVATE";

            //DirectoryInfo di = new DirectoryInfo(path);
            //DirectorySecurity acl = di.GetAccessControl(AccessControlSections.All);
            //AuthorizationRuleCollection rules = acl.GetAccessRules(true, true, typeof(NTAccount));

            ////Go through the rules returned from the DirectorySecurity
            //foreach (AuthorizationRule rule in rules)
            //{
            //    //If we find one that matches the identity we are looking for
            //    if (rule.IdentityReference.Value.Equals(NtAccountName, StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        var filesystemAccessRule = (FileSystemAccessRule)rule;

            //        //Cast to a FileSystemAccessRule to check for access rights
            //        if ((filesystemAccessRule.FileSystemRights & FileSystemRights.WriteData) > 0 && filesystemAccessRule.AccessControlType != AccessControlType.Deny)
            //        {
            //            Console.WriteLine(string.Format("{0} has write access to {1}", NtAccountName, path));
            //        }
            //        else
            //        {
            //            Console.WriteLine(string.Format("{0} does not have write access to {1}", NtAccountName, path));
            //        }
            //    }
            //}
            //string path = @"D:\My Tasks\FinalAssessment\UploadFolder\asdasd\asdd\asdasd";
            //string[] splitpath = path.Split(Convert.ToChar(92));

            //Console.WriteLine(path);
            //foreach (string sp in splitpath)
            //{
            //    Console.WriteLine(sp);
            //}

            

           
            string full = @"D:\My Tasks\FinalAssessment\UploadFolder\asdasd\asdd\UploadFolder";
            string[] Arr = full.Split('\\');
            foreach (string s in Arr)
            {
                path += s + "\\";
                Console.WriteLine(path);
            }
            Console.ReadKey();

           
            //foreach (string s in splitpath)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.ReadKey();


        }

        public static bool DirectoryHasPermission(string DirectoryPath, FileSystemRights AccessRight)
        {
            if (string.IsNullOrEmpty(DirectoryPath)) return false;

            try
            {
                AuthorizationRuleCollection rules = Directory.GetAccessControl(DirectoryPath).GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
                WindowsIdentity identity = WindowsIdentity.GetCurrent();

                foreach (FileSystemAccessRule rule in rules)
                {
                    if (identity.Groups.Contains(rule.IdentityReference))
                    {
                        if ((AccessRight & rule.FileSystemRights) == AccessRight)
                        {
                            if (rule.AccessControlType == AccessControlType.Allow)
                                return true;
                        }
                    }
                }
            }
            catch { }
            return false;
        }
        private static SecureString GetPassword()
        {
            ConsoleKeyInfo info;
            //Get the user's password as a SecureString  
            SecureString securePassword = new SecureString();
            do
            {
                info = Console.ReadKey(true);
                if (info.Key != ConsoleKey.Enter)
                {
                    securePassword.AppendChar(info.KeyChar);
                }
            }
            while (info.Key != ConsoleKey.Enter);
            return securePassword;
        }


        public static void EventChannelGetData()
        {

            using (SqlConnection connection = new SqlConnection())
            {


                SqlDataAdapter da = new SqlDataAdapter();
                connection.ConnectionString = constring;

                connection.Open();

                //string sql = "select * from FileInfo";
                //SqlCommand sqlCommand = new SqlCommand(sql, connection);
                //SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                //da.Fill(ds);
                //sql = "select * from RootFolder";
                //sqlCommand = new SqlCommand(sql, connection);
                //da = new SqlDataAdapter(sqlCommand);
                //da.Fill(ds);
                //sql = "select * from SubFolder";
                //sqlCommand = new SqlCommand(sql, connection);
                //da = new SqlDataAdapter(sqlCommand);

                //da.Fill(ds);
                //return ds;


                SqlCommand commd1 = new SqlCommand("select * from RootFolder", connection);
              
                //SqlCommand commd3 = new SqlCommand("select * from FileInfo", connection);

                ds.Tables.Add("RootFolder");
                ds.Tables.Add("SubFolder");
                ds.Tables.Add("FileInfo");

                da.SelectCommand = commd1;
                da.Fill(ds.Tables["RootFolder"]);
               
                //da.SelectCommand = commd3;
                //da.Fill(ds.Tables["FileInfo"]);
               
            }
        }

         static void GetSUbFolderTable(string id)
        {
            using (SqlConnection connection = new SqlConnection())
            {


                SqlDataAdapter da = new SqlDataAdapter();
                connection.ConnectionString = constring;

                connection.Open();

                SqlCommand commd2 = new SqlCommand("select * from SubFolder where RootFolderId="+id, connection);
                da.SelectCommand = commd2;
                da.Fill(ds.Tables["SubFolder"]);
            }
        }

        //static  void deleteSharedWithEveryoneFolder()
        //{
        //     List<string> folderNames = new List<string>();
        //    folderNames.Add("Folder 1");
        //    folderNames.Add("Folder 2");
        //    folderNames.Add("Folder 3");
           
        //    context.Credentials = new SharePointOnlineCredentials("arvind.torvi@acuvate.com", s);
        //    Web web = context.Web;
        //    Web webroot = context.Site.RootWeb;
        //    context.Load(webroot);
        //    context.Load(web);
        //    List list = context.Web.Lists.GetByTitle("Documents");
        //    context.Load(list);
        //    FolderCollection folders = list.RootFolder.Folders;
        //    context.Load(folders);
        //    context.ExecuteQuery();
            
        //    foreach (string folderName in folderNames)
        //    {
        //        string folderUrl = web.ServerRelativeUrl + "/Shared Documents/"+folderName;
        //        string folderUrlFOldername = folderUrl.Split('/').Last();
        //        if (folderName.ToLower() == folderUrlFOldername.ToLower())
        //        {

        //            var folderToDelete = web.GetFolderByServerRelativeUrl(folderUrl);
        //            folderToDelete.DeleteObject();
        //            context.ExecuteQuery();
        //        }
        //    }

        //}



    }
}
