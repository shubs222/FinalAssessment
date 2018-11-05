using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace DAL.Model
{
    class ConnectionString
    {


        public static String Constr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstr"].ConnectionString;

        //public static String Constr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstr"].ConnectionString;
    }
}
