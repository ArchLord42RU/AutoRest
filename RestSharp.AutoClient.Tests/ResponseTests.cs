using System.Threading.Tasks;
using AutoRestClient.Tests.Fixtures;
using AutoRestClient.Tests.HttpBin;
using NUnit.Framework;

namespace AutoRestClient.Tests
{
    public class ResponseTests
    {
        [Test]
        public async Task Should_Get_Body_Async()
        {
            var response = await GetClient().GetBodyAsync();
            
            CollectionAssert.IsNotEmpty(response?.Headers);
        }
        
        [Test]
        public void Should_Get_Body_Sync()
        {
            var response = GetClient().GetBodySync();
            
            CollectionAssert.IsNotEmpty(response?.Headers);
        }
        
        [Test]
        public async Task Should_Get_Body_As_Bytes_Async()
        {
            var response = await GetClient().GetBytesBodyAsync();
            
            Assert.Greater(response?.Length ?? 0, 0);
        }
        
        [Test]
        public async Task Should_Get_Only_Header()
        {
            var contentType = await GetClient().GetHeaderAsync();
            
            Assert.AreEqual("application/json", contentType);
        }
        
        private static IHttpBinAnythingClient GetClient()
            => HttpClientFixture.GetHttpBinClient();
    }
}