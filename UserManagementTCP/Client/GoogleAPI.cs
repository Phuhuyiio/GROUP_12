public class GoogleBooksAPI
{
    private const string BaseUrl = "https://www.googleapis.com/books/v1/";
    private readonly string apiKey = "AIzaSyAhfnAG8y05BglFPH1Mvst4MpL_ljjdd5g"; // Thay bằng API Key của bạn

    private readonly HttpClient httpClient;

    public GoogleBooksAPI()
    {
        httpClient = new HttpClient();
    }

    // Tìm kiếm sách
    public async Task<string> SearchBookAsync(string query)
    {
        string url = $"{BaseUrl}volumes?q={query}&key={apiKey}";
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi khi gọi Google Books API: " + ex.Message);
        }
    }

    // Lấy thông tin chi tiết của một cuốn sách
    public async Task<string> GetBookDetailsAsync(string bookId)
    {
        string url = $"{BaseUrl}volumes/{bookId}?key={apiKey}";
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi khi lấy thông tin chi tiết sách: " + ex.Message);
        }
    }
}
