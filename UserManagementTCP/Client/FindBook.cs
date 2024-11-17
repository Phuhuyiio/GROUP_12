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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
namespace Client
{
    public partial class FindBook : Form
    {
        public FindBook()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {


            string query = txtSearch.Text.Trim(); // Lấy từ khóa từ TextBox
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm sách!");
                return;
            }

            progressBar1.Visible = true; // Hiển thị ProgressBar trong thời gian chờ
            try
            {
                GoogleBooksAPI api = new GoogleBooksAPI();
                string jsonResponse = await api.SearchBookAsync(query);

                // Parse kết quả JSON
                var books = Newtonsoft.Json.Linq.JObject.Parse(jsonResponse)["items"];
                if (books == null)
                {
                    MessageBox.Show("Không tìm thấy sách nào khớp với từ khóa tìm kiếm.");
                    return; // Thoát khỏi phương thức
                }
                dgvBooks.Rows.Clear(); // Xóa danh sách cũ trong DataGridView
                foreach (var book in books)
                {
                    string id = book["id"]?.ToString();
                    string title = book["volumeInfo"]["title"]?.ToString() ?? "Không có tiêu đề";
                    string authors = string.Join(", ", book["volumeInfo"]["authors"]?.ToObject<string[]>() ?? new string[0]);
                    string description = book["volumeInfo"]["description"]?.ToString() ?? "Không có mô tả";
                    dgvBooks.Rows.Add(id, title, authors, description);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm sách: {ex.Message}");
            }
            finally
            {
                progressBar1.Visible = false; // Ẩn ProgressBar
            }


        }

        private async void btnCreateBookshelf_Click(object sender, EventArgs e)
        {



            string shelfName = txtBookshelfTitle.Text.Trim(); // Tên kệ sách từ TextBox
            string shelfDescription = txtBookshelfDescription.Text.Trim(); // Mô tả kệ sách từ TextBox

            if (string.IsNullOrEmpty(shelfName))
            {
                MessageBox.Show("Vui lòng nhập tên kệ sách!");
                return;
            }

            progressBar1.Visible = true; // Hiển thị ProgressBar trong thời gian chờ
            try
            {
                GoogleBooksOAuthService api = new GoogleBooksOAuthService();
                await api.InitializeAsync(); // Khởi tạo dịch vụ

                // Gọi GetBookshelvesAsync để kiểm tra kệ sách
                bool exists = await api.GetBookshelvesAsync(shelfName, shelfDescription);

                if (exists)
                {
                    MessageBox.Show("Kệ sách đã tồn tại!");
                    BookDetails booksDetailForm = new BookDetails();
                    booksDetailForm.ShelfName = shelfName; // Truyền tên kệ sách sang form BooksDetail
                    booksDetailForm.Show();

                    this.Hide(); // Ẩn form hiện tại
                }
                else
                {
                    MessageBox.Show("Kệ sách chưa tồn tại. Bạn có thể tạo kệ sách mới (nếu API hỗ trợ).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra kệ sách: {ex.Message}");
            }
            finally
            {
                progressBar1.Visible = false; // Ẩn ProgressBar
            }




        }
        private void InitializeDataGridView()
        {
            dgvBooks.Columns.Clear(); // Xóa các cột cũ nếu có
            dgvBooks.Columns.Add("id", "ID Sách");
            dgvBooks.Columns.Add("title", "Tiêu Đề");
            dgvBooks.Columns.Add("authors", "Tác Giả");
            dgvBooks.Columns.Add("description", "Mô Tả");
        }

        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
                // Kiểm tra xem có hàng nào được chọn không
                if (e.RowIndex >= 0 && e.RowIndex < dgvBooks.Rows.Count)
                {
                    // Lấy thông tin từ hàng được chọn
                    DataGridViewRow selectedRow = dgvBooks.Rows[e.RowIndex];
                    string bookId = selectedRow.Cells["id"].Value?.ToString();
                    string title = selectedRow.Cells["title"].Value?.ToString();
                    string authors = selectedRow.Cells["authors"].Value?.ToString();
                    string description = selectedRow.Cells["description"].Value?.ToString();

                    // Tạo form BookDetails và truyền thông tin
                    BookDetails bookDetailsForm = new BookDetails
                    {
                        BookId = bookId,
                        Title = title,
                        Authors = authors,
                        Description = description
                    };

                    // Hiển thị form BookDetails
                    bookDetailsForm.Show();
                }
            

        }
    }
}
