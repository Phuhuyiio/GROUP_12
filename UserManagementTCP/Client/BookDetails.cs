using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class BookDetails : Form
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Description { get; set; }
        public string ShelfName { get; set; } // Thuộc tính để lưu tên kệ sách
        public BookDetails()
        {
            InitializeComponent();
        }



        private async void btnAddToShelf_Click(object sender, EventArgs e)
        {

           
              

                if (string.IsNullOrEmpty(BookId) || string.IsNullOrEmpty(ShelfName))
                {
                    MessageBox.Show("Vui lòng nhập ID sách và ID kệ sách!");
                    return;
                }

                progressBar.Visible = true; // Hiển thị ProgressBar
                try
                {
                    // Khởi tạo GoogleBooksOAuthService
                    GoogleBooksOAuthService api = new GoogleBooksOAuthService();
                    await api.InitializeAsync(); // Gọi InitializeAsync để khởi tạo dịch vụ

                    // Gọi AddBookToShelfAsync để thêm sách vào kệ
                    bool success = await api.AddBookToShelfAsync(ShelfName, BookId);

                    if (success)
                    {
                        MessageBox.Show("Thêm sách vào kệ thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm sách vào kệ.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm sách vào kệ: {ex.Message}");
                }
                finally
                {
                    progressBar.Visible = false; // Ẩn ProgressBar
               }
            

        }

        private async void btnRemoveFromShelf_Click(object sender, EventArgs e)
        {

           
           
                if (string.IsNullOrEmpty(ShelfName) || string.IsNullOrEmpty(BookId))
                {
                    MessageBox.Show("Vui lòng nhập ID kệ sách và ID sách!");
                    return;
                }

                progressBar.Visible = true; // Hiển thị ProgressBar
                try
                {
                    // Khởi tạo GoogleBooksOAuthService
                    GoogleBooksOAuthService api = new GoogleBooksOAuthService();
                    await api.InitializeAsync(); // Gọi InitializeAsync để khởi tạo dịch vụ

                    // Gọi RemoveBookFromShelfAsync để xóa sách khỏi kệ
                    bool success = await api.RemoveBookFromShelfAsync(ShelfName, BookId);

                    if (success)
                    {
                        MessageBox.Show("Xóa sách khỏi kệ thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa sách khỏi kệ.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sách khỏi kệ: {ex.Message}");
                }
                finally
                {
                    progressBar.Visible = false; // Ẩn ProgressBar
                }
            



        }

        private void BookDetails_Load(object sender, EventArgs e)
        {
            // Hiển thị tên kệ sách trong giao diện hoặc xử lý
            if (!string.IsNullOrEmpty(ShelfName))
            {
                lblShelfName.Text = $"Kệ sách: {ShelfName}";
            }
            string bookInfo = $"ID Sách: {BookId}\n" +
                         $"Tiêu Đề: {Title}\n" +
                         $"Tác Giả: {Authors}\n" +
                         $"Mô Tả: {Description}";

            rtbBookDetails.Text = bookInfo;
        }
    }
}

    


