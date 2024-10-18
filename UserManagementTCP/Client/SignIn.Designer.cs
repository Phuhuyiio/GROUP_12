namespace Client
{
    partial class SignIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbUserName = new TextBox();
            btnExecute = new Button();
            lbUserName = new Label();
            lbPassword = new Label();
            tbPassword = new TextBox();
            lbToSignUP = new Label();
            ckbShowPassword = new CheckBox();
            SuspendLayout();
            // 
            // tbUserName
            // 
            tbUserName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbUserName.Location = new Point(278, 166);
            tbUserName.Name = "tbUserName";
            tbUserName.PlaceholderText = "Username";
            tbUserName.Size = new Size(338, 39);
            tbUserName.TabIndex = 0;
            // 
            // btnExecute
            // 
            btnExecute.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExecute.Location = new Point(413, 311);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(203, 44);
            btnExecute.TabIndex = 2;
            btnExecute.Text = "Đăng Nhập";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // lbUserName
            // 
            lbUserName.AutoSize = true;
            lbUserName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserName.Location = new Point(79, 169);
            lbUserName.Name = "lbUserName";
            lbUserName.Size = new Size(174, 32);
            lbUserName.TabIndex = 3;
            lbUserName.Text = "Tên đăng nhập";
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPassword.Location = new Point(79, 230);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(115, 32);
            lbPassword.TabIndex = 5;
            lbPassword.Text = "Mật khẩu";
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.Location = new Point(278, 227);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Password";
            tbPassword.Size = new Size(338, 39);
            tbPassword.TabIndex = 4;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // lbToSignUP
            // 
            lbToSignUP.AutoSize = true;
            lbToSignUP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbToSignUP.Location = new Point(100, 317);
            lbToSignUP.Name = "lbToSignUP";
            lbToSignUP.Size = new Size(307, 32);
            lbToSignUP.TabIndex = 6;
            lbToSignUP.Text = "Chưa có tài khoản? Đăng kí";
            lbToSignUP.Click += lbToSignUP_Click;
            // 
            // ckbShowPassword
            // 
            ckbShowPassword.AutoSize = true;
            ckbShowPassword.Location = new Point(286, 275);
            ckbShowPassword.Name = "ckbShowPassword";
            ckbShowPassword.Size = new Size(178, 29);
            ckbShowPassword.TabIndex = 7;
            ckbShowPassword.Text = "Hiển thị mật khẩu";
            ckbShowPassword.UseVisualStyleBackColor = true;
            ckbShowPassword.CheckedChanged += ckbShowPassword_CheckedChanged;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ckbShowPassword);
            Controls.Add(lbToSignUP);
            Controls.Add(lbPassword);
            Controls.Add(tbPassword);
            Controls.Add(lbUserName);
            Controls.Add(btnExecute);
            Controls.Add(tbUserName);
            Name = "SignIn";
            Text = "Đăng Nhập";
            FormClosed += SignIn_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUserName;
        private Button btnExecute;
        private Label lbUserName;
        private Label lbPassword;
        private TextBox tbPassword;
        private Label lbToSignUP;
        private CheckBox ckbShowPassword;
    }
}