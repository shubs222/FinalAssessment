using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UploadDataRepository
    {
        static string constring = "Data Source = ACUPC_113; Initial Catalog = FolderUpload; Integrated Security = True";
        public DataSet GetRootFolders()
        {

            using (SqlConnection connection = new SqlConnection())
            {
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter();
                connection.ConnectionString = constring;

                connection.Open();



                SqlCommand commd1 = new SqlCommand("select Name,Path from RootFolder", connection);

                //SqlCommand commd3 = new SqlCommand("select * from FileInfo", connection);

                ds.Tables.Add("RootFolder");
                //ds.Tables.Add("SubFolder");
                //ds.Tables.Add("FileInfo");

                da.SelectCommand = commd1;
                da.Fill(ds.Tables["RootFolder"]);

                //da.SelectCommand = commd3;
                //da.Fill(ds.Tables["FileInfo"]);
                return ds;
            }
        }
        public DataTable GetRootTable()
        {
            // This will hold the records.
            DataTable dataTable = new DataTable();


            // Prep command object.
            string sql = "select Name,Path from RootFolder";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = constring;
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    // Fill the DataTable with data from the reader and clean up.
                    dataTable.Load(dataReader);
                    dataReader.Close();
                }
            }
            return dataTable;
        }
    }


}
