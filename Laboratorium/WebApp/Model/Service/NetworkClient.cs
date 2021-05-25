namespace Model.Service
{
    using System.Diagnostics;
    using System.Net.Http;
    using Data;
    using Utilities;
    using static System.String;

    public class NetworkClient : INetwork
    {
        private readonly ServiceClient _serviceClient;

        public NetworkClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !IsNullOrEmpty(serviceHost) && servicePort > 0);

            _serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public MatchData[] GetMatches()
        {
            const string callUri = "examination-rooms-selection";

            var nodes = _serviceClient.CallWebServiceAsync<MatchData[]>(HttpMethod.Get, callUri);

            return nodes.Result;
        }
    }
}