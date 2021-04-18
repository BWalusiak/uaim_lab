namespace PatientsApp.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Configuration;
    using Dtos;
    using Mapper;
    using PatientsData.Infrastructure.Models;

    public class PatientsDataServiceClient : IPatientsDataServiceClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ServiceConfiguration _serviceConfiguration;

        public PatientsDataServiceClient(IHttpClientFactory clientFactory, ServiceConfiguration serviceConfiguration)
        {
            _clientFactory = clientFactory;
            _serviceConfiguration = serviceConfiguration;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.PatientsDataUrl}/patients");
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var patientDtos = await JsonSerializer.DeserializeAsync<IEnumerable<PatientDto>>(responseStream, options);

            return patientDtos?.Select(dto => dto.UnMap());
        }

        public async Task<IEnumerable<Patient>> GetAllByConditionId(int type)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.PatientsDataUrl}/select-condition?type=" + type);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var patientDtos = await JsonSerializer.DeserializeAsync<IEnumerable<PatientDto>>(responseStream, options);
            return patientDtos?.Select(dto => dto.UnMap());
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.PatientsDataUrl}/patient-id?id=" + id);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var patientDto = await JsonSerializer.DeserializeAsync<PatientDto>(responseStream, options);

            return patientDto?.UnMap();
        }

        public async Task<Patient> GetPatientByPesel(string pesel)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_serviceConfiguration.PatientsDataUrl}/patient-pesel?pesel=" + pesel);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var patientDto = await JsonSerializer.DeserializeAsync<PatientDto>(responseStream, options);
            return patientDto?.UnMap();
        }

        public void AddPatient(Patient patient)
        {
            var jsonString = JsonSerializer.Serialize(patient);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient();
            var url = $"{_serviceConfiguration.PatientsDataUrl}/add-patient";
            client.PostAsync(url, content);
        }
    }

    public interface IPatientsDataServiceClient
    {
        public Task<IEnumerable<Patient>> GetAllPatientsAsync();
        public Task<IEnumerable<Patient>> GetAllByConditionId(int type);

        public Task<Patient> GetPatientById(int id);
        public Task<Patient> GetPatientByPesel(string pesel);

        public void AddPatient(Patient patient);
    }
}