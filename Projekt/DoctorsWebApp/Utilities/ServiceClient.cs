namespace Utilities
{
    using System.Diagnostics;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class ServiceClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private readonly string _serviceUrl;

        public ServiceClient(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
        }

        public R CallWebService<R>(HttpMethod httpMethod, string webServiceUri)
        {
            var webServiceCall = CallWebService(httpMethod, webServiceUri);

            webServiceCall.Wait();

            var jsonResponseContent = webServiceCall.Result;

            return ConvertJson<R>(jsonResponseContent);
        }

        public async Task<R> CallWebServiceAsync<R>(HttpMethod httpMethod, string webServiceUri)
        {
            var jsonResponseContent = await CallWebService(httpMethod, webServiceUri);

            return ConvertJson<R>(jsonResponseContent);
        }

        public async Task<R> CallWebServiceAsync<R>(string webServiceUri, object obj)
        {
            var jsonResponseContent = await CallWebServiceWithContent(webServiceUri, obj);

            return ConvertJson<R>(jsonResponseContent);
        }

        private async Task<string> CallWebService(HttpMethod httpMethod, string callUri)
        {
            var httpUri = $"{_serviceUrl}/{callUri}";

            var httpRequestMessage = new HttpRequestMessage(httpMethod, httpUri);

            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        private async Task<string> CallWebServiceWithContent(string callUri, object obj)
        {
            var httpUri = $"{_serviceUrl}{callUri}";

            var jsonString = JsonConvert.SerializeObject(obj);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var httpResponseMessage = await HttpClient.PostAsync(httpUri, content);

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        private T ConvertJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}