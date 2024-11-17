using Azure.Core;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SignIn : Form
    {
        ClientTCPConnection conn = new ClientTCPConnection();
        public SignIn()
        {
            InitializeComponent();
            conn.CreateSocket();
            conn.Connect();
        }

        public static string user;
        string fail = "Fail";
        string success = "Succ";

        private void lbToSignUP_Click(object sender, EventArgs e)
        {
            SignUp displaySignUp = new SignUp();
            displaySignUp.Show();
            this.Hide();
        }

        private void SignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            //conn.Close();
            Application.Exit();
        }

        string Encryption(string input) //Encrypting password
        {
            HashAlgorithm alg = SHA256.Create(); //use SHA256 Encryption
            byte[] inputBytes = Encoding.UTF8.GetBytes(input); //Turning input into byte array
            byte[] hashBytes = alg.ComputeHash(inputBytes); //Hash byte array
            string HashPassword = BitConverter.ToString(hashBytes); //Turn byte array into string
            return HashPassword;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Tên người dùng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Accountquery = @"Select * From Users Where (Username = '" + tbUserName.Text.Trim() + "') AND (Password = '" + Encryption(tbPassword.Text.Trim()) + "')";
                conn.Send(Accountquery);
                string us = conn.Recieve().Substring(0, 4);
                if (us == fail)
                {
                    user = tbUserName.Text.Trim();
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FindBook displayFindBook = new FindBook();
                    displayFindBook.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void ckbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowPassword.Checked) tbPassword.UseSystemPasswordChar = false;
            else tbPassword.UseSystemPasswordChar = true;
        }
    }
}
