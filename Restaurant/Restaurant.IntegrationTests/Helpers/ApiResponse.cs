using System.Net;

namespace Restaurant.IntegrationTests
{
    public class ApiResponse
    {
        public object ResponseContent { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
