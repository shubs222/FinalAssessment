using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace UploadFolder
{
    public class PermissionRepository
    {
        public void InsertInto(string DatabaseTableName, string SqlQuery)

        {

            SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=FolderUpload;Integrated Security=True");

            SqlCommand cmd = new SqlCommand(SqlQuery, cn);

            cn.Open();

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public DataTable GetMappingRole(string MappedRole)
        {

            SqlDataAdapter adapter;
            using (SqlConnection connection = new SqlConnection())
            {
                DataTable RolesInfoTable = new DataTable();
                connection.ConnectionString = @"Data Source=ACUPC_0114;Initial Catalog=FolderUpload;Integrated Security=True";
                connection.Open();
                string SqlQuery = "select RoleType from RoleTypes  where Id in (select RoleTypesId from FolderToSPPermissions where FolderPermissionsId = (select Id from FolderPermissions where PermissionLevel = '" + MappedRole + "')); ";
                adapter = new SqlDataAdapter(SqlQuery, connection);
                adapter.Fill(RolesInfoTable);
                connection.Close();
                return RolesInfoTable;
            }
        }
    }
}
