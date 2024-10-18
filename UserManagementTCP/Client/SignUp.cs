using System.DirectoryServices;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Client
{
    public partial class SignUp : Form
    {
        ClientTCPConnection conn = new ClientTCPConnection();
        public SignUp()
        {
            InitializeComponent();
            conn.CreateSocket();
            conn.Connect();
        }

        string fail = "Fail";
        string success = "Succ";
        string Encryption(string input) //Encrypting password
        {
            HashAlgorithm alg = SHA256.Create(); //use SHA256 Encryption
            byte[] inputBytes = Encoding.UTF8.GetBytes(input); //Turning input into byte array
            byte[] hashBytes = alg.ComputeHash(inputBytes); //Hash byte array
            string HashPassword = BitConverter.ToString(hashBytes); //Turn byte array into string
            return HashPassword;
        }

        private void lbToSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn displaySignIn = new SignIn();
            displaySignIn.Show();
        }

        public bool CheckUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z_0-9]{3,20}$");
        }

        public bool CheckEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[a-zA-Z0-9]{3,20}@gmail.com$")
                || Regex.IsMatch(email, @"^[a-zA-Z0-9]{3,20}@gm.uit.edu.vn$"))
            {
                return true;
            }
            else return false;
        }

        public bool CheckFullName(string fullname)
        {
            if (Regex.IsMatch(fullname, @"^[(\s+)(\p{Ll})(\p{Lu})a-zA-Z_]{3,50}$"))
                return true;
            else return false;
        }

        bool CheckDate(string date)
        {
            bool x = Regex.IsMatch(date, @"^[0-9/]{8,10}$");

            if (!x) return false;

            string[] arr = date.Split('/');

            if (arr.Length != 3) return false;
            if (arr[0].Length < 1 && arr[0].Length > 2) return false;
            if (arr[1].Length < 1 && arr[1].Length > 2) return false;
            if (arr[2].Length != 4) return false;

            int day = Int32.Parse(arr[0]);
            int month = Int32.Parse(arr[1]);
            int year = Int32.Parse(arr[2]);
            int[] cal = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (year <= 0) return false;
            if (year % 4 == 0 && year % 100 != 0)
            {
                cal[1] = 29;
            }
            else cal[1] = 28;
            if (month >= 1 && month <= 12)
            {
                if (day >= 1 && day <= cal[month - 1])
                {
                }
                else return false;
            }
            else return false;

            if (arr[0].Length < 2) arr[0] = "0" + arr[0];
            if (arr[1].Length < 2) arr[1] = "0" + arr[1];

            date = arr[0] + "/" + arr[1] + "/" + arr[2];

            DateTime today = DateTime.Today;
            DateTime dt = DateTime.ParseExact(date, "dd/mm/yyyy", CultureInfo.InvariantCulture);

            if (dt >= today) return false;
            return true;
        }

        bool CheckPassword(string pass)
        {
            return pass.Length >= 8 ? true : false;
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Tên người dùng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbFullName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Họ và tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Email không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbBirthDay.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ngày sinh không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CheckUsername(tbUserName.Text.Trim()) == false)
                {
                    MessageBox.Show("Tên người dùng không hợp lệ!" +
                        "\nTên người dùng chỉ được bao gồm chữ hoa, chữ thường, chữ số và dấu gạch dưới(_). ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (CheckFullName(tbFullName.Text) == false)
                {
                    MessageBox.Show("Họ và tên không hợp lệ!" +
                        "\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (CheckEmail(tbEmail.Text.Trim()) == false)
                {
                    MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (CheckDate(tbBirthDay.Text.Trim()) == false)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ!" +
                        "\nVui lòng nhập lại theo mẫu dd/mm/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (CheckPassword(tbPassword.Text.Trim()) == false)
                {
                    MessageBox.Show("Mật khẩu không hợp lệ!" +
                        "\nYêu cầu mật khẩu có ít nhất 8 kí tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbConfirmPassword.Text.Trim() != tbPassword.Text.Trim())
                {
                    MessageBox.Show("Vui lòng xác minh lại mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        string Usernamequery = "Select * From Users Where Username = '" + tbUserName.Text.Trim() + "'";
                        conn.Send(Usernamequery);
                        string us = conn.Recieve().Substring(0, 4);
                        if (us == fail)
                        {
                            MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string Emailquery = "Select * From Users Where Email = '" + tbEmail.Text.Trim() + "'";
                        conn.Send(Emailquery);
                        string em = conn.Recieve().Substring(0, 4);
                        if (em == fail)
                        {
                            MessageBox.Show("Email đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string pass = Encryption(tbPassword.Text.Trim());
                        string query = "Insert Into Users(Username, Password, Email, FullName, BirthDay) " +
                            "Values ('" + tbUserName.Text.Trim() + "', '" + pass + "', '" + tbEmail.Text.Trim() + "', '" + tbFullName.Text + "', '" + tbBirthDay.Text.Trim() + "')";
                        conn.Send(query);
                        string rs = conn.Recieve().Substring(0, 4);
                        if (rs == success)
                        {
                            MessageBox.Show("Đăng ký thành công! " + rs, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            SignIn displaySignIn = new SignIn();
                            displaySignIn.Show();
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại! " + rs, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
            Application.Exit();
        }

        private void ckbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowPassword.Checked) tbPassword.UseSystemPasswordChar = false;
            else tbPassword.UseSystemPasswordChar = true;

        }

        private void ckbShowConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowConfirmPassword.Checked) tbConfirmPassword.UseSystemPasswordChar = false;
            else tbConfirmPassword.UseSystemPasswordChar = true;
        }
    }
}
