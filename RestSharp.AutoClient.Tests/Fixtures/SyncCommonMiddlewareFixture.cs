using System;
using AutoRestClient.Processing;

namespace AutoRestClient.Tests.Fixtures
{
    public class SyncCommonMiddlewareFixture: RestCallMiddleware
    {
        public static bool Called { get; set; }
        
        public override void Invoke(ExecutionContext context, Action<ExecutionContext> next)
        {
            Called = true;
            next(context);
        }
    }
}