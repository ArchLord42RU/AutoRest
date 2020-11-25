using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRestClient.Client;
using AutoRestClient.Tests.HttpBin;
using AutoRestClient.Tests.HttpBin.Models;
using NUnit.Framework;

namespace AutoRestClient.Tests
{
    public class AutoRestClientTests
    {
        private const string QueryParamValue = "query-param-value";
        private const string HeaderParamValue = "x-header-value"; 
        
        private IHttpBinAnythingClient _anythingClient;
        
        [SetUp]
        public void Setup()
        {
            var builder = new AutoClientBuilder<IHttpBinAnythingClient>()
                .WithConfiguration(configuration =>
                {
                    configuration.BaseUri = new Uri("https://httpbin.org");
                });

            _anythingClient = builder.Build();
        }
        
        [Test]
        public async Task Should_Get_Body_Async()
        {
            var response = await _anythingClient.GetBodyAsync();
            
            CollectionAssert.IsNotEmpty(response?.Headers);
        }
        
        [Test]
        public void Should_Get_Body_Sync()
        {
            var response = _anythingClient.GetBodySync();
            
            CollectionAssert.IsNotEmpty(response?.Headers);
        }
        
        [Test]
        public async Task Should_Get_Body_As_Bytes_Async()
        {
            var response = await _anythingClient.GetBytesBodyAsync();
            
            Assert.Greater(response?.Length ?? 0, 0);
        }

        [Test]
        public async Task Should_Check_Params_Binding_Binding()
        {
            var response = await _anythingClient.PostWithBindingsAsync(QueryParamValue, HeaderParamValue);
            
            Assert.AreEqual("POST", response.Method);
            
            Assert.True(response.Args.Any(x 
                => x.Key.Equals("queryParam", StringComparison.InvariantCultureIgnoreCase) && x.Value == QueryParamValue));
            
            Assert.True(response.Headers.Any(x 
                => x.Key.Equals("x-header-1", StringComparison.InvariantCultureIgnoreCase) && x.Value == HeaderParamValue));
            
            Assert.True(response.Headers.Any(x 
                => x.Key.Equals("x-header-2", StringComparison.InvariantCultureIgnoreCase) && x.Value == HeaderParamValue));
            
            Assert.True(response.Headers.Any(x 
                => x.Key.Equals("x-header-3", StringComparison.InvariantCultureIgnoreCase) && x.Value == HeaderParamValue));
            
            Assert.True(response.Url.Contains("/foo"));
        }

        [Test]
        public async Task Should_Get_Only_Header()
        {
            var contentType = await _anythingClient.GetHeaderAsync();
            
            Assert.AreEqual("application/json", contentType);
        }

        [Test]
        public async Task Should_Post_Bound_Request()
        {
            var req = new AnythingRequest
            {
                Header = HeaderParamValue,
                QueryParam = QueryParamValue,
                Body = new Dictionary<string, string>
                {
                    {"key", "value"}
                }
            };

            var response = await _anythingClient.PostJson(req);
            
            Assert.True(response.Body.Args.Any(x 
                => x.Key.Equals("queryParam", StringComparison.InvariantCultureIgnoreCase) && x.Value == QueryParamValue));
            
            Assert.True(response.Body.Headers.Any(x 
                => x.Key.Equals("x-header-1", StringComparison.InvariantCultureIgnoreCase) && x.Value == HeaderParamValue));
            
            Assert.True(response.Body.Json.Any(x => x.Key == "key" && x.Value == "value"));
            
            Assert.AreEqual(false, string.IsNullOrEmpty(response.Server));
        }
    }
}