using CategoryService.Dtos;
using System.Net.Http;
using System.Text;
using System.Text.Json;
namespace CategoryService.NewsClient
{
    public class NewsService:IClientUpdate
    {
        private HttpClient _httpClient;

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Send(NewsCategoryCreate newsCategoryRead)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(newsCategoryRead),Encoding.UTF8
                ,"application/json");

            var result = await _httpClient.PostAsync("http://localhost:5056/api/news", content);

            if (result.IsSuccessStatusCode)
            {
                return "ok";
            }

            return "not ok";
        }
    }
}
