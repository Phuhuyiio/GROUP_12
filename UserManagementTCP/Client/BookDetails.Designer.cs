namespace Client
{
    partial class BookDetails
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
            rtbBookDetails = new RichTextBox();
            btnAddToShelf = new Button();
            btnRemoveFromShelf = new Button();
            progressBar = new ProgressBar();
            lblShelfName = new Label();
            SuspendLayout();
            // 
            // rtbBookDetails
            // 
            rtbBookDetails.Location = new Point(198, 12);
            rtbBookDetails.Name = "rtbBookDetails";
            rtbBookDetails.Size = new Size(353, 164);
            rtbBookDetails.TabIndex = 0;
            rtbBookDetails.Text = "";
            // 
            // btnAddToShelf
            // 
            btnAddToShelf.Location = new Point(36, 57);
            btnAddToShelf.Name = "btnAddToShelf";
            btnAddToShelf.Size = new Size(138, 23);
            btnAddToShelf.TabIndex = 1;
            btnAddToShelf.Text = "Thêm vào kệ sách";
            btnAddToShelf.UseVisualStyleBackColor = true;
            btnAddToShelf.Click += btnAddToShelf_Click;
            // 
            // btnRemoveFromShelf
            // 
            btnRemoveFromShelf.Location = new Point(36, 95);
            btnRemoveFromShelf.Name = "btnRemoveFromShelf";
            btnRemoveFromShelf.Size = new Size(138, 23);
            btnRemoveFromShelf.TabIndex = 2;
            btnRemoveFromShelf.Text = "Xóa khỏi kệ sách";
            btnRemoveFromShelf.UseVisualStyleBackColor = true;
            btnRemoveFromShelf.Click += btnRemoveFromShelf_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(69, 182);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(417, 24);
            progressBar.TabIndex = 3;
            // 
            // lblShelfName
            // 
            lblShelfName.AutoSize = true;
            lblShelfName.Location = new Point(69, 15);
            lblShelfName.Name = "lblShelfName";
            lblShelfName.Size = new Size(69, 15);
            lblShelfName.TabIndex = 4;
            lblShelfName.Text = "Tên Kệ Sách";
            // 
            // BookDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 221);
            Controls.Add(lblShelfName);
            Controls.Add(progressBar);
            Controls.Add(btnRemoveFromShelf);
            Controls.Add(btnAddToShelf);
            Controls.Add(rtbBookDetails);
            Name = "BookDetails";
            Text = "BookDetails";
            Load += BookDetails_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbBookDetails;
        private Button btnAddToShelf;
        private Button btnRemoveFromShelf;
        private ProgressBar progressBar;
        private Label lblShelfName;
    }
}