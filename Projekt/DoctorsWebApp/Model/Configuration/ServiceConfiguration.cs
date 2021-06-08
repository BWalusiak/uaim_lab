namespace Model.Configuration
{
    using System;

    public class ServiceConfiguration
    {
        public ServiceConfiguration()
        {
            BackendUrl = "";
        }

        public ServiceConfiguration(string backendUrl)
        {
            BackendUrl = backendUrl ?? throw new ArgumentNullException(nameof(backendUrl));
        }

        public string BackendUrl { get; set; }
    }
}
