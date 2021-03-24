namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Dtos;

    public class DoctorsServiceClient : IDoctorsServiceClient
    {
        private readonly IHttpClientFactory _clientFactory;
        
        public DoctorsServiceClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "http://localhost:44500/doctors");
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<DoctorDto>>(responseStream, options);
        }
    }
}