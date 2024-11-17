using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Server
{
    internal class DataBaseConnection
    {
        //Apply the DataSource by changing the value of connectionString
        private static string connectionString = @"Data Source=DESKTOP-7K2H2VJ\MSSQLSERVER01;Initial Catalog=UserManagement;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }
    }
}
