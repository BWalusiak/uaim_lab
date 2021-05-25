namespace Model.Service
{
    public static class NetworkClientFactory
    {
        public static INetwork GetNetworkClient()
        {
#if DEBUG
            return new FakeNetworkClient();
#else
            const string serviceHost = "roomselector-app";
            const int servicePort = 80;

            return new NetworkClient( serviceHost, servicePort );
#endif
        }
    }
}