namespace PatientsApp.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Configuration;
    using Dtos;
    using Infrastrucutre.Models;
    using Mapper;

    public class DoctorsDataServiceClient : IDoctorsDataServiceClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ServiceConfiguration _serviceConfiguration;

        public DoctorsDataServiceClient(IHttpClientFactory clientFactory, ServiceConfiguration serviceConfiguration)
        {
            _clientFactory = clientFactory;
            _serviceConfiguration = serviceConfiguration;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecializationId(int type)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.DoctorsDataUrl}/select-specialization?type=" + type);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var doctorDtos = await JsonSerializer.DeserializeAsync<IEnumerable<DoctorDto>>(responseStream, options);

            return doctorDtos?.Select(dto => dto.UnMap());
        }
    }

    public interface IDoctorsDataServiceClient
    {
        public Task<IEnumerable<Doctor>> GetDoctorsBySpecializationId(int id);
    }
}