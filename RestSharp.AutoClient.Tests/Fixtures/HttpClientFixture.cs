using System;
using AutoRestClient.Client;
using AutoRestClient.Tests.HttpBin;

namespace AutoRestClient.Tests.Fixtures
{
    public static class HttpClientFixture
    {
        public const string QueryParamValue = "query-param-value";
        public const string HeaderParamValue = "x-header-value";
        
        public static IHttpBinAnythingClient GetHttpBinClient(Action<RestClientConfiguration<IHttpBinAnythingClient>> setupAction = default)
        {
            var builder = new AutoClientBuilder<IHttpBinAnythingClient>()
                .WithConfiguration(configuration =>
                {
                    configuration.BaseUri = new Uri("https://httpbin.org");
                    setupAction?.Invoke(configuration);
                });

            return builder.Build();
        }
    }
}