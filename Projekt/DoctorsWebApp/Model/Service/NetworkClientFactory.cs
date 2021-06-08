namespace Model.Service
{
    using Configuration;

    public static class NetworkClientFactory
    {
        public static INetworkClient GetNetworkClient(ServiceConfiguration configuration)
        {
            return new NetworkClient(configuration);
        }
    }
}