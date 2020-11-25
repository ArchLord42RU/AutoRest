using AutoRestClient.Tests.HttpBin;
using Microsoft.Extensions.DependencyInjection;

namespace RestSharp.AutoClient.Examples.Di.Microsoft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            var provider = serviceCollection.BuildServiceProvider();

            var client = provider.GetRequiredService<IHttpBinAnythingClient>();
        }
    }
}