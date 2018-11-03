using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Security;
using Microsoft.SharePoint.Client;
using System.Threading;

namespace UploadFolder
{
    public partial class Main : System.Windows.Forms.Form
    {
        static SecureString str = GetPassword();
       
        static ClientContext context = new ClientContext("https://acuvatehyd.sharepoint.com/teams/shubhamtrial");
        public Main()
        {
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {


            UploadProgressBar.Visible = true;
            ProgressBarTimer.Start();
            context.Credentials = new SharePointOnlineCredentials("arvind.torvi@acuvate.com", str);
            //UploadDataRepository uploadData = new UploadDataRepository();
            //DataTable dataTable = uploadData.GetRootTable();
            //foreach (DataRow dataRow in dataTable.Rows)
            //{
            //    SPUploadFolder.UploadFoldersRecursively(context, dataRow["Path"].ToString()+@"\"+dataRow["Name"].ToString(), "Documents");
            //}

            //MessageBox.Show("Folders Are Uploaded Successfully");
            string path = "D:\asd\asd";// selected  rootfolder path;
            string CbDocumentlibrary = "documents";//selected doccument library

            string[] splitpath = path.Split(Convert.ToChar(92));


            if (splitpath.Length > 2)
            {
                //__________________if rootfolder path have more than one folders___________________//
                SPUploadFolder.CreateFolder(context, path, CbDocumentlibrary);
            }
            else
            {
                //__________________if rootfolder path have one folder___________________//
                SPUploadFolder.UploadFoldersRecursively(context, path, CbDocumentlibrary);
            }


        }
       
        private static SecureString GetPassword()
        {
            string pass = "";
            //Get the user's password as a SecureString  
            SecureString securePassword = new SecureString();
            foreach (char password in pass)
            {
                securePassword.AppendChar(password);

            }
            
            return securePassword;
        }

       

     
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.UploadProgressBar.Increment(1);
            if (UploadProgressBar.Value == 100)
            {
                ProgressBarTimer.Stop();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
