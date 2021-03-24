namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Dtos;

    public class ExaminationRoomsServiceClient : IExaminationRoomsServiceClient
    {
        private readonly IHttpClientFactory _clientFactory;

        public ExaminationRoomsServiceClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<ExaminationRoomDto>> GetAllExaminationRoomsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "http://rooms/examination-rooms");
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<ExaminationRoomDto>>(responseStream, options);
        }
    }

    public interface IExaminationRoomsServiceClient
    {
        Task<IEnumerable<ExaminationRoomDto>> GetAllExaminationRoomsAsync();
    }
}