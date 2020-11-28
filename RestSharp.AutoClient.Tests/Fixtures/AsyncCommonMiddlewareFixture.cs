﻿using System;
using System.Threading.Tasks;
using AutoRestClient.Processing;

namespace AutoRestClient.Tests.Fixtures
{
    public class AsyncCommonMiddlewareFixture: AsyncRestCallMiddleware
    {
        public static bool Called { get; set; }

        public override async Task InvokeAsync(ExecutionContext context, Func<ExecutionContext, Task> next)
        {
            Called = true;
            await next(context);
        }
    }
}