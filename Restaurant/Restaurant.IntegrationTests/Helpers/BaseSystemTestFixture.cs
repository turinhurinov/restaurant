using System.Threading.Tasks;

namespace Restaurant.IntegrationTests
{
    public class BaseSystemTestFixture
    {
        #region members

        readonly ApiClient client;

        string ServiceBaseUrl => "https://localhost:44345/";

        #endregion

        #region ctor

        public BaseSystemTestFixture()
        {
            client = new ApiClient();
        }

        #endregion


        protected async Task<ApiResponse> SendPostRequest(string url, object requestData)
        {
            string endpointUrl = CreateEndPointUrl(url);

            return await client.SendPostAsync(endpointUrl, requestData);
        }


        string CreateEndPointUrl(string url)
        {
            return $"{ServiceBaseUrl}{url}";
        }
    }
}