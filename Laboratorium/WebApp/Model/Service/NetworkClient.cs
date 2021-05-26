namespace Model.Service
{
    using System.Diagnostics;
    using System.Net.Http;
    using Configuration;
    using Data;
    using Utilities;
    using static System.String;

    public class NetworkClient : INetwork
    {
        private readonly ServiceClient _serviceClient;

        public NetworkClient(ServiceConfiguration configuration)
        {
            _serviceClient = new ServiceClient(configuration.BackendUrl);
        }

        public MatchData[] GetMatches()
        {
            const string callUri = "examination-rooms-selection";

            var nodes = _serviceClient.CallWebServiceAsync<MatchData[]>(HttpMethod.Get, callUri);

            return nodes.Result;
        }
    }
}