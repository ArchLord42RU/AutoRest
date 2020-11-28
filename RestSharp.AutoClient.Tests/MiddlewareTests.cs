using System;
using System.Threading.Tasks;
using AutoRestClient.Processing;
using AutoRestClient.Tests.Fixtures;
using AutoRestClient.Tests.HttpBin;
using AutoRestClient.Tests.HttpClients.FakeClient;
using Moq;
using NUnit.Framework;

namespace AutoRestClient.Tests
{
    public class MiddlewareTests
    {
        [SetUp]
        public void Setup()
        {
            SyncCommonMiddlewareFixture.Called = false;
            AsyncCommonMiddlewareFixture.Called = false;
        }
        
        [Test]
        public async Task Should_Call_Middlewares_From_Assembly()
        {
            var client = HttpClientFixture.GetHttpBinClient(configuration =>
            {
                configuration.AddMiddlewares(new []
                {
                    GetType().Assembly
                });
            });

            var result = await client.GetHeaderAsync();
            
            Assert.True(SyncCommonMiddlewareFixture.Called);
            Assert.True(AsyncCommonMiddlewareFixture.Called);
        }

        [Test]
        public async Task Should_Check_Middlewares_Calling()
        {
            var commonMiddleware = new Mock<IRestCallMiddleware>();
            var typedMiddleware = new Mock<IRestCallMiddleware<IHttpBinAnythingClient>>();
            var neverCalledMiddleware = new Mock<IRestCallMiddleware<IFakeHttpClient>>();
            
            var client = HttpClientFixture.GetHttpBinClient(configuration =>
            {
                configuration.AddMiddleware(commonMiddleware);
                configuration.AddMiddleware(typedMiddleware);
                configuration.AddMiddleware(neverCalledMiddleware);
                configuration.AddMiddleware(typeof(AsyncCommonMiddlewareFixture));
            });

            var result = await client.GetHeaderAsync();

            commonMiddleware.Verify(x => x.Invoke(It.IsAny<ExecutionContext>(),
                It.IsAny<Action<ExecutionContext>>()), Times.Once);
            
            typedMiddleware.Verify(x => x.Invoke(It.IsAny<ExecutionContext>(),
                It.IsAny<Action<ExecutionContext>>()), Times.Once);
            
            neverCalledMiddleware.Verify(x => x.Invoke(It.IsAny<ExecutionContext>(),
                It.IsAny<Action<ExecutionContext>>()), Times.Never);

            Assert.True(AsyncCommonMiddlewareFixture.Called);
        }
    }
}