using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL.Model;

namespace DAL.Repository
{
    public class SPFolderUploadRepository
    {
        //public DataTable GetSubFolderData(string rootFolderId)
        //{
        //    DataTable SubFolderData = new DataTable();
        //    using (SqlConnection ConnnnectionObj = new SqlConnection(DAL.Model.ConnectionString.Constr))
        //    {


        //        string Query = "Select Id,RootFolderId,Name,Path From SubFolder where RootFolderId=" + Convert.ToInt32(rootFolderId);
        //        using (SqlCommand Command = new SqlCommand(Query, ConnnnectionObj))
        //        {
        //            SqlDataReader dataReader = Command.ExecuteReader();
        //            // Fill the DataTable with data from the reader and clean up.
        //            SubFolderData.Load(dataReader);
        //            dataReader.Close();
        //        }
        //    }
        //    return SubFolderData;
        //}
        public string RootFolderPath(int rootFolderId)
        {
            string RootfolderPath="";
            using (SqlConnection Connection = new SqlConnection())
            {
                Connection.ConnectionString = ConnectionString.Constr;
                Connection.Open();
                string sql = "Select Path From RootFolder where Id="+rootFolderId;
                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    SqlDataReader DataReader = command.ExecuteReader();
                    if (DataReader.Read())
                    {
                        RootfolderPath = DataReader.GetString(0);
                    }
                }
            }
            return RootfolderPath;
        }
        public DataTable GetSubFolderData(int rootFolderId)
        {

            
            using (SqlConnection Connection = new SqlConnection())
            {
                DataTable RolesInfoTable = new DataTable();
                Connection.ConnectionString = ConnectionString.Constr;
                Connection.Open();
                string SqlQuery = "Select Id,RootFolderId,Name,Path From SubFolder where RootFolderId=" +rootFolderId;
                SqlDataAdapter Adapter = new SqlDataAdapter(SqlQuery, Connection);
                Adapter.Fill(RolesInfoTable);
                Connection.Close();
                return RolesInfoTable;
            }
        }
        public DataTable GetFileInformation(int SubFolderId)
        {

            using (SqlConnection Connection = new SqlConnection())
            {
                DataTable RolesInfoTable = new DataTable();
                Connection.ConnectionString = ConnectionString.Constr;
                Connection.Open();
                string SqlQuery = "Select * From FileInfo where SubFolderId=" + SubFolderId+"and IsFilePathOK=1 and IsFilesupported = 1";
                SqlDataAdapter Adapter = new SqlDataAdapter(SqlQuery, Connection);
                Adapter.Fill(RolesInfoTable);
                Connection.Close();
                return RolesInfoTable;
            }
        }

    }


}

