namespace DoctorsApp.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Configuration;
    using Dtos;

    public class PatientsDataServiceClient : IPatientsDataServiceClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ServiceConfiguration _serviceConfiguration;

        public PatientsDataServiceClient(IHttpClientFactory clientFactory, ServiceConfiguration serviceConfiguration)
        {
            _clientFactory = clientFactory;
            _serviceConfiguration = serviceConfiguration;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatients()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.PatientsDataUrl}/patients");
            request.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return await JsonSerializer.DeserializeAsync<IEnumerable<PatientDto>>(responseStream, options);
        }

        public async Task<PatientDto> GetPatientById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.PatientsDataUrl}/patient-id?id=" + id);
            request.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return await JsonSerializer.DeserializeAsync<PatientDto>(responseStream, options);
        }

        public async Task<IEnumerable<PatientDto>> GetPatientsByCondition(int condition)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.PatientsDataUrl}/select-condition?type=" + condition);
            request.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return await JsonSerializer.DeserializeAsync<IEnumerable<PatientDto>>(responseStream, options);
        }

        public async Task<PatientDto> GetPatientByPesel(string pesel)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.PatientsDataUrl}/patient-pesel?pesel=" + pesel);
            request.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return await JsonSerializer.DeserializeAsync<PatientDto>(responseStream, options);
        }

        public void AddPatient(PatientDto patientDto)
        {
            var jsonString = JsonSerializer.Serialize(patientDto);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient();
            var url = $"{_serviceConfiguration.PatientsDataUrl}/add-patient";
            client.PostAsync(url, content);
        }
    }
}