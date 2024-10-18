using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class DataBaseConnection
    {
        //Apply the DataSource by changing the value of connectionString
        private static string connectionString = @"Data Source=LAPTOP-RK9EOKK4\MSSQLSERVER03;Initial Catalog=UserManagement;Integrated Security=True;Trust Server Certificate=True";

        public static SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }
    }
}
