using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL.Model;

namespace UploadFolder
{
    public class PermissionRepository
    {
        public void InsertInto(string DatabaseTableName, string SqlQuery)

        {
            SqlConnection Connection = new SqlConnection(ConnectionString.Constr);

            SqlCommand Command = new SqlCommand(SqlQuery, Connection);

            Connection.Open();

            Command.ExecuteNonQuery();

            Connection.Close();
        }

        public DataTable GetMappingRole(string MappedRole)
        {
           
            SqlDataAdapter Adapter;
            using (SqlConnection connection = new SqlConnection())
            {
                DataTable RolesInfoTable = new DataTable();
                connection.ConnectionString = ConnectionString.Constr;
                connection.Open();
                string SqlQuery = "select RoleType from RoleTypes  where Id in (select RoleTypesId from FolderToSPPermissions where FolderPermissionsId = (select Id from FolderPermissions where PermissionLevel = '"+MappedRole+"')); ";  
                Adapter = new SqlDataAdapter(SqlQuery, connection);
                Adapter.Fill(RolesInfoTable);             
                connection.Close();
                return RolesInfoTable;
            }
        }
    }
}
