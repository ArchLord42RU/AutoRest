using System;
using AutoRestClient.Processing;

namespace AutoRestClient.Tests.Fixtures
{
    public class SyncCommonMiddlewareFixture: IRestCallMiddleware
    {
        public static bool Called { get; private set; }
        
        public void Invoke(ExecutionContext context, Action<ExecutionContext> next)
        {
            Called = true;
        }
    }
}