using System;
using System.Threading.Tasks;
using AutoRestClient.Processing;
using AutoRestClient.Tests.HttpClients.FakeClient;

namespace AutoRestClient.Tests.Fixtures
{
    public class FakeClientMiddleware: AsyncRestCallMiddleware<IFakeHttpClient>
    {
        public static bool Called { get; set; }
        
        public override async Task InvokeAsync(ExecutionContext context, Func<ExecutionContext, Task> next)
        {
            Called = true;
            await next(context);
        }
    }
}