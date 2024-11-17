using Google.Apis.Auth.OAuth2;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class GoogleBooksOAuthService
{
    private BooksService booksService;

    /// <summary>
    /// Khởi tạo dịch vụ Google Books với xác thực OAuth2.
    /// </summary>
    public async Task InitializeAsync()
    {
        try
        {
            Console.WriteLine("Bắt đầu khởi tạo Google Books service...");
            var clientSecrets = new ClientSecrets
            {
                ClientId = "585737608062-mevl8tnj65v4hlu697bu7afovjpr1smv.apps.googleusercontent.com", // Thay bằng Client ID của bạn
                ClientSecret = "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" // Thay bằng Client Secret của bạn
            };

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                new[] { BooksService.Scope.Books },
                "user",
                CancellationToken.None
            );

            if (credential == null)
            {
                throw new Exception("Không thể xác thực OAuth2. Credential null.");
            }

            booksService = new BooksService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Desktop client 1"
            });

            if (booksService == null)
            {
                throw new Exception("Khởi tạo booksService thất bại.");
            }

            Console.WriteLine("Google Books service đã được khởi tạo thành công.");
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi khi khởi tạo Google Books service: " + ex.Message);
        }
    }

    /// <summary>
    /// Tạo một kệ sách mới.
    /// </summary>
    /// <param name="name">Tên kệ sách.</param>
    /// <param name="description">Mô tả kệ sách.</param>
    /// <returns>True nếu thành công, ngược lại False.</returns>
    public async Task<bool> GetBookshelvesAsync(string shelfName, string shelfDescription)
    {
        try
        {
            if (booksService == null)
            {
                throw new Exception("Google Books service chưa được khởi tạo.");
            }

            var shelvesRequest = booksService.Mylibrary.Bookshelves.List();
            var shelves = await shelvesRequest.ExecuteAsync();

            if (shelves?.Items != null)
            {
                foreach (var shelf in shelves.Items)
                {
                    if (shelf.Title == shelfName)
                    {
                        // Kệ sách đã tồn tại
                        return true;
                    }
                }
            }

            // Nếu không tồn tại, bạn có thể thêm logic để xử lý
            return false;
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi khi lấy danh sách kệ sách: " + ex.Message);
        }
    }



    /// <summary>
    /// Thêm một cuốn sách vào kệ sách.
    /// </summary>
    /// <param name="shelfId">ID của kệ sách.</param>
    /// <param name="bookId">ID của cuốn sách.</param>
    /// <returns>True nếu thành công, ngược lại False.</returns>
    public async Task<bool> AddBookToShelfAsync(string shelfId, string bookId)
    {
        try
        {
            // Kiểm tra booksService đã được khởi tạo
            if (booksService == null)
            {
                throw new Exception("Google Books service chưa được khởi tạo. Hãy chắc chắn gọi InitializeAsync() trước khi sử dụng dịch vụ.");
            }

            string url = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/{shelfId}/addVolume?volumeId={bookId}";
            HttpResponseMessage response = await booksService.HttpClient.PostAsync(url, null);
            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi khi thêm sách vào kệ: " + ex.Message);
        }
    }


    /// <summary>
    /// Xóa một cuốn sách khỏi kệ sách.
    /// </summary>
    /// <param name="shelfId">ID của kệ sách.</param>
    /// <param name="bookId">ID của cuốn sách.</param>
    /// <returns>True nếu thành công, ngược lại False.</returns>
    public async Task<bool> RemoveBookFromShelfAsync(string shelfId, string bookId)
    {
        try
        {
            // Kiểm tra booksService đã được khởi tạo
            if (booksService == null)
            {
                throw new Exception("Google Books service chưa được khởi tạo. Hãy chắc chắn gọi InitializeAsync() trước khi sử dụng dịch vụ.");
            }

            string url = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/{shelfId}/removeVolume?volumeId={bookId}";
            HttpResponseMessage response = await booksService.HttpClient.PostAsync(url, null);
            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi khi xóa sách khỏi kệ: " + ex.Message);
        }
    }


    /// <summary>
    /// Kiểm tra hoặc tạo một kệ sách mặc định.
    /// </summary>
    /// <param name="shelfName">Tên kệ sách mặc định.</param>
    /// <param name="shelfDescription">Mô tả kệ sách mặc định.</param>
    /// <returns>ID của kệ sách mặc định.</returns>
    public async Task<string> EnsureDefaultShelfExistsAsync(string shelfName, string shelfDescription)
    {
        try
        {
            // Kiểm tra booksService đã được khởi tạo
            if (booksService == null)
            {
                throw new Exception("Google Books service chưa được khởi tạo. Hãy chắc chắn gọi InitializeAsync() trước khi sử dụng dịch .");
            }

            var shelvesRequest = booksService.Mylibrary.Bookshelves.List();
            var shelves = await shelvesRequest.ExecuteAsync();

            if (shelves?.Items != null)
            {
                foreach (var shelf in shelves.Items)
                {
                    // Kiểm tra nếu shelf không null và thuộc tính Title tồn tại
                    if (shelf?.Title == shelfName)
                    {
                        // Chuyển đổi shelf.Id sang string nếu cần
                        return shelf.Id.ToString();
                    }
                }
            }

            // Tạo kệ sách mới nếu chưa tồn tại
            var bookshelf = new
            {
                title = shelfName,
                description = shelfDescription
            };

            string url = "https://www.googleapis.com/books/v1/mylibrary/bookshelves";
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(bookshelf), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage createResponse = await booksService.HttpClient.PostAsync(url, content);
            createResponse.EnsureSuccessStatusCode();

            string responseData = await createResponse.Content.ReadAsStringAsync();
            var newShelf = Newtonsoft.Json.Linq.JObject.Parse(responseData);

            return newShelf["id"]?.ToString() ?? throw new Exception("Không thể tạo kệ sách mới.");
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi khi kiểm tra hoặc tạo kệ sách mặc định: " + ex.Message);
        }
    }
}
