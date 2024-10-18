using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Main : Form
    {
        ClientTCPConnection conn = new ClientTCPConnection();
        Account User = new Account();
        string fail = "Fail";
        string success = "Succ";

        void LoadInfo(string username)
        {
            string userQuery = "SELECT * From Users Where Username = '" + username + "'";
            conn.Send(userQuery);
            string rs = conn.Recieve();
            if (rs.Substring(0, 4) != fail)
            {
                string[] arr = rs.Split('*');
                tbUsername.Text = arr[1];
                tbEmail.Text = arr[2];
                tbFullname.Text = arr[3];
                tbBirthday.Text = arr[4];
            }
            else
            {
                MessageBox.Show("Không lấy được thông tin tài khoảng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Main()
        {
            InitializeComponent();

            conn.CreateSocket();
            conn.Connect();

            LoadInfo(SignIn.user);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            Application.Exit();
        }
    }
}
