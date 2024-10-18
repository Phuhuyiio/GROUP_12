using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;

namespace Server
{
    class ManipulateDataBase
    {
        public ManipulateDataBase()
        {

        }

        private SqlCommand cmd; //Contain command
        private SqlDataReader dataReader; //Read data from database

        public static string Encryption(string input) //Encrypting password
        {
            HashAlgorithm alg = SHA256.Create(); //use SHA256 Encryption
            byte[] inputBytes = Encoding.UTF8.GetBytes(input); //Turning input into byte array
            byte[] hashBytes = alg.ComputeHash(inputBytes); //Hash byte array
            string HashPassword = BitConverter.ToString(hashBytes); //Turn byte array into string
            return HashPassword;
        }

        public List<Account> ToQuery(string query) //Query data in database
        {
            List<Account> DataList = new List<Account>(); //Contain users which meet the conditions
            using (SqlConnection sqlConnection = DataBaseConnection.Connect())
            {
                sqlConnection.Open();

                cmd = new SqlCommand(query, sqlConnection);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read()) //Adding data into DataList
                {
                    DataList.Add(new Account(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetDateTime(5).ToShortDateString()));
                }//                             UserId                 Username                 Password(Encypted)         Email                    Fullname                Birthday       

                sqlConnection.Close();
                return DataList;
            }
        }

        public void Command(string query) //Execute command
        {
            using (SqlConnection sqlConnection = DataBaseConnection.Connect())
            {
                sqlConnection.Open();

                cmd = new SqlCommand(query, sqlConnection);
                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public Account GetAccount(string query) //Get information of any user
        {
            using (SqlConnection sqlConnection = DataBaseConnection.Connect())
            {
                Account acc = new Account();
                sqlConnection.Open();

                cmd = new SqlCommand(query, sqlConnection);
                dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    acc = new Account(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetDateTime(5).ToShortDateString());
                }

                sqlConnection.Close();
                return acc;
            }
        }

        //public bool CheckExits(string col, string val)
        //{
        //    using (SqlConnection sqlConnection = DataBaseConnection.Connect())
        //    {
        //        string query = "Select * From Users Where " + col + " = '" + val + "'";
        //        sqlConnection.Open();

        //        cmd = new SqlCommand(query, sqlConnection);
        //        dataReader = cmd.ExecuteReader();
        //        if (dataReader.Read())
        //        {
        //            sqlConnection.Close();
        //            return true;
        //        }

        //        sqlConnection.Close();
        //        return false;
        //    }
        //}
    }
}
