namespace Client
{
    partial class SignUp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbUserName = new TextBox();
            tbFullName = new TextBox();
            tbEmail = new TextBox();
            tbBirthDay = new TextBox();
            tbPassword = new TextBox();
            tbConfirmPassword = new TextBox();
            lbUserName = new Label();
            lbFullName = new Label();
            lbEmail = new Label();
            lbBirthDay = new Label();
            lbPassword = new Label();
            lbConfirmPassword = new Label();
            btnExecute = new Button();
            lbToSignIn = new Label();
            ckbShowPassword = new CheckBox();
            ckbShowConfirmPassword = new CheckBox();
            SuspendLayout();
            // 
            // tbUserName
            // 
            tbUserName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbUserName.Location = new Point(361, 113);
            tbUserName.Name = "tbUserName";
            tbUserName.PlaceholderText = "Tên người dùng";
            tbUserName.Size = new Size(283, 39);
            tbUserName.TabIndex = 0;
            // 
            // tbFullName
            // 
            tbFullName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFullName.Location = new Point(361, 179);
            tbFullName.Name = "tbFullName";
            tbFullName.PlaceholderText = "Họ tên";
            tbFullName.Size = new Size(283, 39);
            tbFullName.TabIndex = 1;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbEmail.Location = new Point(361, 248);
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderText = "Email";
            tbEmail.Size = new Size(283, 39);
            tbEmail.TabIndex = 2;
            // 
            // tbBirthDay
            // 
            tbBirthDay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbBirthDay.Location = new Point(361, 310);
            tbBirthDay.Name = "tbBirthDay";
            tbBirthDay.PlaceholderText = "dd/mm/yyyy";
            tbBirthDay.Size = new Size(283, 39);
            tbBirthDay.TabIndex = 3;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.Location = new Point(361, 383);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Mật khẩu";
            tbPassword.Size = new Size(283, 39);
            tbPassword.TabIndex = 4;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // tbConfirmPassword
            // 
            tbConfirmPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbConfirmPassword.Location = new Point(361, 465);
            tbConfirmPassword.Name = "tbConfirmPassword";
            tbConfirmPassword.PlaceholderText = "Xác nhận mật khẩu";
            tbConfirmPassword.Size = new Size(283, 39);
            tbConfirmPassword.TabIndex = 5;
            tbConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lbUserName
            // 
            lbUserName.AutoSize = true;
            lbUserName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserName.Location = new Point(131, 116);
            lbUserName.Name = "lbUserName";
            lbUserName.Size = new Size(184, 32);
            lbUserName.TabIndex = 6;
            lbUserName.Text = "Tên người dùng";
            // 
            // lbFullName
            // 
            lbFullName.AutoSize = true;
            lbFullName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbFullName.Location = new Point(131, 186);
            lbFullName.Name = "lbFullName";
            lbFullName.Size = new Size(118, 32);
            lbFullName.TabIndex = 7;
            lbFullName.Text = "Họ và tên";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEmail.Location = new Point(131, 251);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(71, 32);
            lbEmail.TabIndex = 8;
            lbEmail.Text = "Email";
            // 
            // lbBirthDay
            // 
            lbBirthDay.AutoSize = true;
            lbBirthDay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbBirthDay.Location = new Point(131, 313);
            lbBirthDay.Name = "lbBirthDay";
            lbBirthDay.Size = new Size(121, 32);
            lbBirthDay.TabIndex = 9;
            lbBirthDay.Text = "Ngày sinh";
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPassword.Location = new Point(131, 386);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(115, 32);
            lbPassword.TabIndex = 10;
            lbPassword.Text = "Mật khẩu";
            // 
            // lbConfirmPassword
            // 
            lbConfirmPassword.AutoSize = true;
            lbConfirmPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbConfirmPassword.Location = new Point(131, 472);
            lbConfirmPassword.Name = "lbConfirmPassword";
            lbConfirmPassword.Size = new Size(219, 32);
            lbConfirmPassword.TabIndex = 11;
            lbConfirmPassword.Text = "Xác nhận mật khẩu";
            // 
            // btnExecute
            // 
            btnExecute.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExecute.Location = new Point(505, 543);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(139, 47);
            btnExecute.TabIndex = 12;
            btnExecute.Text = "Đăng kí";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // lbToSignIn
            // 
            lbToSignIn.AutoSize = true;
            lbToSignIn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbToSignIn.Location = new Point(168, 550);
            lbToSignIn.Name = "lbToSignIn";
            lbToSignIn.Size = new Size(317, 32);
            lbToSignIn.TabIndex = 13;
            lbToSignIn.Text = "Đã có tài khoản? Đăng nhập";
            lbToSignIn.Click += lbToSignIn_Click;
            // 
            // ckbShowPassword
            // 
            ckbShowPassword.AutoSize = true;
            ckbShowPassword.Location = new Point(364, 428);
            ckbShowPassword.Name = "ckbShowPassword";
            ckbShowPassword.Size = new Size(178, 29);
            ckbShowPassword.TabIndex = 14;
            ckbShowPassword.Text = "Hiển thị mật khẩu";
            ckbShowPassword.UseVisualStyleBackColor = true;
            ckbShowPassword.CheckedChanged += ckbShowPassword_CheckedChanged;
            // 
            // ckbShowConfirmPassword
            // 
            ckbShowConfirmPassword.AutoSize = true;
            ckbShowConfirmPassword.Location = new Point(361, 510);
            ckbShowConfirmPassword.Name = "ckbShowConfirmPassword";
            ckbShowConfirmPassword.Size = new Size(178, 29);
            ckbShowConfirmPassword.TabIndex = 15;
            ckbShowConfirmPassword.Text = "Hiển thị mật khẩu";
            ckbShowConfirmPassword.UseVisualStyleBackColor = true;
            ckbShowConfirmPassword.CheckedChanged += ckbShowConfirmPassword_CheckedChanged;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 644);
            Controls.Add(ckbShowConfirmPassword);
            Controls.Add(ckbShowPassword);
            Controls.Add(lbToSignIn);
            Controls.Add(btnExecute);
            Controls.Add(lbConfirmPassword);
            Controls.Add(lbPassword);
            Controls.Add(lbBirthDay);
            Controls.Add(lbEmail);
            Controls.Add(lbFullName);
            Controls.Add(lbUserName);
            Controls.Add(tbConfirmPassword);
            Controls.Add(tbPassword);
            Controls.Add(tbBirthDay);
            Controls.Add(tbEmail);
            Controls.Add(tbFullName);
            Controls.Add(tbUserName);
            Name = "SignUp";
            Text = "Đăng Kí";
            FormClosing += SignUp_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUserName;
        private TextBox tbFullName;
        private TextBox tbEmail;
        private TextBox tbBirthDay;
        private TextBox tbPassword;
        private TextBox tbConfirmPassword;
        private Label lbUserName;
        private Label lbFullName;
        private Label lbEmail;
        private Label lbBirthDay;
        private Label lbPassword;
        private Label lbConfirmPassword;
        private Button btnExecute;
        private Label lbToSignIn;
        private CheckBox ckbShowPassword;
        private CheckBox ckbShowConfirmPassword;
    }
}
