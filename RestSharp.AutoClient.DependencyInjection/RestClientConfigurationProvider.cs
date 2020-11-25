using AutoRestClient.Client;

namespace RestSharp.AutoClient.DependencyInjection
{
    /// <summary>
    /// Marker provider class for easy registering in DI containers
    /// </summary>
    /// <typeparam name="TClient">type of client</typeparam>
    public class RestClientConfigurationProvider<TClient>: RestClientConfigurationProvider
    {
        public RestClientConfigurationProvider(RestClientConfiguration configuration) : base(configuration)
        {
            
        }
    }
}