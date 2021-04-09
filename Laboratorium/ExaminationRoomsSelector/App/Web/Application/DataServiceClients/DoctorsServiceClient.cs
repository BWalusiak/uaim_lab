namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Configuration;
    using Dtos;

    public class DoctorsServiceClient : IDoctorsServiceClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ServiceConfiguration _serviceConfiguration;

        public DoctorsServiceClient(IHttpClientFactory clientFactory, ServiceConfiguration serviceConfiguration)
        {
            _clientFactory = clientFactory;
            _serviceConfiguration = serviceConfiguration;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.DoctorsUrl}/doctors");
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<DoctorDto>>(responseStream, options);
        }

        public void AddDoctor(DoctorDto doctorDto)
        {
            var jsonString = JsonSerializer.Serialize(doctorDto);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();

            var url = $"{_serviceConfiguration.DoctorsUrl}/doctor";

            var result = client.PostAsync(url, content).Result;
        }
    }

    public interface IDoctorsServiceClient
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        void AddDoctor(DoctorDto doctorDto);
    }
}