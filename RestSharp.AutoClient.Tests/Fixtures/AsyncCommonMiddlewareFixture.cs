using System;
using System.Threading.Tasks;
using AutoRestClient.Processing;

namespace AutoRestClient.Tests.Fixtures
{
    public class AsyncCommonMiddlewareFixture: IAsyncRestCallMiddleware
    {
        public static bool Called { get; set; }
        
        public async Task InvokeAsync(ExecutionContext context, Func<ExecutionContext, Task> next)
        {
            Called = true;
        }
    }
}