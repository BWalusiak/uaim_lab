namespace Utilities
{
    using System.Diagnostics;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ServiceClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private readonly string _serviceUrl;

        public ServiceClient(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
        }

        public TR CallWebService<TR>(HttpMethod httpMethod, string webServiceUri)
        {
            var webServiceCall = CallWebService(httpMethod, webServiceUri);

            webServiceCall.Wait();

            var jsonResponseContent = webServiceCall.Result;

            var result = ConvertJson<TR>(jsonResponseContent);

            return result;
        }

        public async Task<TR> CallWebServiceAsync<TR>(HttpMethod httpMethod, string webServiceUri)
        {
            var jsonResponseContent = await CallWebService(httpMethod, webServiceUri);

            var result = ConvertJson<TR>(jsonResponseContent);

            return result;
        }

        private async Task<string> CallWebService(HttpMethod httpMethod, string callUri)
        {
            var httpUri = $"{_serviceUrl}/{callUri}";

            var httpRequestMessage = new HttpRequestMessage(httpMethod, httpUri);

            httpRequestMessage.Headers.Add("Accept", "application/json");

            var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        private static T ConvertJson<T>(string json)
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(json, jsonSerializerOptions);
        }
    }
}