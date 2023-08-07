using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.IntegrationTests
{
    public class ApiClient
    {
        readonly HttpClient client = new HttpClient();

        public async Task<ApiResponse> SendPostAsync(string requestUri, object requestData)
        {
            var requestContent = CreatePostRequestContent(requestData);
            var response = await client.PostAsync(requestUri, requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            return new ApiResponse
            {
                ResponseContent = responseContent,
                StatusCode = response.StatusCode
            };
        }

        HttpContent CreatePostRequestContent(object request)
        {
            var requestDataAsJson = JsonConvert.SerializeObject(request);

            return new StringContent(requestDataAsJson, Encoding.UTF8, "application/json");
        }
    }
}
