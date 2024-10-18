namespace Client
{
    partial class Main
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
            tbUsername = new TextBox();
            tbFullname = new TextBox();
            tbEmail = new TextBox();
            tbBirthday = new TextBox();
            lbUserName = new Label();
            lbFullName = new Label();
            lbEmail = new Label();
            lbBirthDay = new Label();
            SuspendLayout();
            // 
            // tbUsername
            // 
            tbUsername.AcceptsReturn = true;
            tbUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbUsername.Location = new Point(340, 113);
            tbUsername.Name = "tbUsername";
            tbUsername.ReadOnly = true;
            tbUsername.Size = new Size(307, 39);
            tbUsername.TabIndex = 0;
            // 
            // tbFullname
            // 
            tbFullname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFullname.Location = new Point(340, 180);
            tbFullname.Name = "tbFullname";
            tbFullname.ReadOnly = true;
            tbFullname.Size = new Size(307, 39);
            tbFullname.TabIndex = 1;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbEmail.Location = new Point(340, 246);
            tbEmail.Name = "tbEmail";
            tbEmail.ReadOnly = true;
            tbEmail.Size = new Size(307, 39);
            tbEmail.TabIndex = 2;
            // 
            // tbBirthday
            // 
            tbBirthday.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbBirthday.Location = new Point(340, 319);
            tbBirthday.Name = "tbBirthday";
            tbBirthday.ReadOnly = true;
            tbBirthday.Size = new Size(307, 39);
            tbBirthday.TabIndex = 3;
            // 
            // lbUserName
            // 
            lbUserName.AutoSize = true;
            lbUserName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserName.Location = new Point(128, 120);
            lbUserName.Name = "lbUserName";
            lbUserName.Size = new Size(184, 32);
            lbUserName.TabIndex = 4;
            lbUserName.Text = "Tên người dùng";
            // 
            // lbFullName
            // 
            lbFullName.AutoSize = true;
            lbFullName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbFullName.Location = new Point(128, 180);
            lbFullName.Name = "lbFullName";
            lbFullName.Size = new Size(87, 32);
            lbFullName.TabIndex = 5;
            lbFullName.Text = "Họ tên";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEmail.Location = new Point(128, 246);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(71, 32);
            lbEmail.TabIndex = 6;
            lbEmail.Text = "Email";
            // 
            // lbBirthDay
            // 
            lbBirthDay.AutoSize = true;
            lbBirthDay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbBirthDay.Location = new Point(128, 319);
            lbBirthDay.Name = "lbBirthDay";
            lbBirthDay.Size = new Size(121, 32);
            lbBirthDay.TabIndex = 7;
            lbBirthDay.Text = "Ngày sinh";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbBirthDay);
            Controls.Add(lbEmail);
            Controls.Add(lbFullName);
            Controls.Add(lbUserName);
            Controls.Add(tbBirthday);
            Controls.Add(tbEmail);
            Controls.Add(tbFullname);
            Controls.Add(tbUsername);
            Name = "Main";
            Text = "Thông Tin Người Dùng";
            FormClosed += Main_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUsername;
        private TextBox tbFullname;
        private TextBox tbEmail;
        private TextBox tbBirthday;
        private Label lbUserName;
        private Label lbFullName;
        private Label lbEmail;
        private Label lbBirthDay;
    }
}