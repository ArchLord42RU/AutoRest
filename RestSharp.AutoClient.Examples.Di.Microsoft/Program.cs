using System;
using System.Threading.Tasks;
using AutoRestClient.Tests.HttpBin;
using AutoRestClient.Tests.HttpBin.Models;
using Microsoft.Extensions.DependencyInjection;

namespace RestSharp.AutoClient.Examples.Di.Microsoft
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddAutoRestClient<IHttpBinAnythingClient>((serviceProvider, configuration) =>
            {
                configuration.BaseUri = new Uri("https://httpbin.org/");
            });
            
            var provider = serviceCollection.BuildServiceProvider();

            var client = provider.GetRequiredService<IHttpBinAnythingClient>();

            var result = await client.PostJson(new AnythingRequest()
            {
                QueryParam = "foo"
            });
        }
    }
}