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
            UploadProgressBar.Show();
           
            context.Credentials = new SharePointOnlineCredentials("arvind.torvi@acuvate.com", str);
            UploadDataRepository uploadData = new UploadDataRepository();
            DataTable dataTable = uploadData.GetRootTable();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                SPUploadFolder.UploadFoldersRecursively(context, dataRow["Path"].ToString()+dataRow["Name"].ToString(), "Documents");
            }
            UploadProgressBar.Hide();
            MessageBox.Show("Folders Are Uploaded Successfully");
        }
       
        private static SecureString GetPassword()
        {
           
            //Get the user's password as a SecureString  
            SecureString securePassword = new SecureString();
            foreach (char password in pass)
            {
                securePassword.AppendChar(password);

            }
            
            return securePassword;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
       

    }
}
