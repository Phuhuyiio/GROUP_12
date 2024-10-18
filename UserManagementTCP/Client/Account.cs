using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Account
    {
        private int userId;
        private string username;
        private string password;
        private string email;
        private string fullname;
        private string birthday;

        public Account()
        {

        }

        public Account(int id, string name, string pass, string mail, string fname, string bday)
        {
            userId = id;
            username = name;
            password = pass;
            email = mail;
            fullname = fname;
            birthday = bday;
        }

        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Birthday { get => birthday; set => birthday = value; }
    }
}
