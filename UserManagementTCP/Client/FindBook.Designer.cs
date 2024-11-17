namespace Client
{
    partial class FindBook
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
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvBooks = new DataGridView();
            btnCreateBookshelf = new Button();
            txtBookshelfDescription = new TextBox();
            txtBookshelfTitle = new TextBox();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(41, 49);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(41, 78);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 28);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm Kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvBooks
            // 
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(174, 12);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.Size = new Size(576, 248);
            dgvBooks.TabIndex = 2;
            dgvBooks.CellDoubleClick += dgvBooks_CellDoubleClick;
            // 
            // btnCreateBookshelf
            // 
            btnCreateBookshelf.Location = new Point(41, 157);
            btnCreateBookshelf.Name = "btnCreateBookshelf";
            btnCreateBookshelf.Size = new Size(100, 28);
            btnCreateBookshelf.TabIndex = 3;
            btnCreateBookshelf.Text = " Tạo kệ sách";
            btnCreateBookshelf.UseVisualStyleBackColor = true;
            btnCreateBookshelf.Click += btnCreateBookshelf_Click;
            // 
            // txtBookshelfDescription
            // 
            txtBookshelfDescription.Location = new Point(41, 220);
            txtBookshelfDescription.Name = "txtBookshelfDescription";
            txtBookshelfDescription.Size = new Size(100, 23);
            txtBookshelfDescription.TabIndex = 4;
            // 
            // txtBookshelfTitle
            // 
            txtBookshelfTitle.Location = new Point(41, 191);
            txtBookshelfTitle.Name = "txtBookshelfTitle";
            txtBookshelfTitle.Size = new Size(100, 23);
            txtBookshelfTitle.TabIndex = 5;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(174, 298);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(576, 23);
            progressBar1.TabIndex = 6;
            // 
            // FindBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 357);
            Controls.Add(progressBar1);
            Controls.Add(txtBookshelfTitle);
            Controls.Add(txtBookshelfDescription);
            Controls.Add(btnCreateBookshelf);
            Controls.Add(dgvBooks);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Name = "FindBook";
            Text = "FindBook";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvBooks;
        private Button btnCreateBookshelf;
        private TextBox txtBookshelfDescription;
        private TextBox txtBookshelfTitle;
        private ProgressBar progressBar1;
    }
}