using AutoRestClient.Client;

namespace RestSharp.AutoClient.DependencyInjection
{
    /// <summary>
    /// Marker configuration class for easy registering in DI containers
    /// </summary>
    /// <typeparam name="TClient">type of client</typeparam>
    public class RestClientConfiguration<TClient>: RestClientConfiguration
    {
        
    }
}