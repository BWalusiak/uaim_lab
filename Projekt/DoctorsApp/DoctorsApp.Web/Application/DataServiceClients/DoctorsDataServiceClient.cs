namespace DoctorsApp.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Configuration;
    using Dtos;

    public class DoctorsDataServiceClient : IDoctorsDataServiceClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ServiceConfiguration _serviceConfiguration;

        public DoctorsDataServiceClient(IHttpClientFactory clientFactory, ServiceConfiguration serviceConfiguration)
        {
            _clientFactory = clientFactory;
            _serviceConfiguration = serviceConfiguration;
        }


        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.DoctorsDataUrl}/doctors");
            request.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return await JsonSerializer.DeserializeAsync<IEnumerable<DoctorDto>>(responseStream, options);
        }

        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.DoctorsDataUrl}/doctor-id?id=" + id);
            request.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return await JsonSerializer.DeserializeAsync<DoctorDto>(responseStream, options);
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialization(int condition)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.DoctorsDataUrl}/select-specialization?type=" + condition);
            request.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return await JsonSerializer.DeserializeAsync<IEnumerable<DoctorDto>>(responseStream, options);
        }

        public async Task<DoctorDto> GetDoctorsByPesel(string pesel)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.DoctorsDataUrl}/doctor-pesel?pesel=" + pesel);
            request.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return await JsonSerializer.DeserializeAsync<DoctorDto>(responseStream, options);
        }

        public void AddDoctor(DoctorDto doctorDto)
        {
            var jsonString = JsonSerializer.Serialize(doctorDto);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient();
            var url = $"{_serviceConfiguration.DoctorsDataUrl}/add-doctor";
            client.PostAsync(url, content);
        }
    }
}