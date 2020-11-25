using System;
using AutoRestClient.Processing;
using Microsoft.Extensions.Logging;

namespace RestSharp.AutoClient.Examples.Di.Microsoft
{
    public class RestClientLogger: IRestCallMiddleware
    {
        private readonly ILogger _logger;

        public RestClientLogger(ILogger logger)
        {
            _logger = logger;
        }
        
        public void Invoke(ExecutionContext context, Action<ExecutionContext> next)
        {
            using var scope = _logger.BeginScope(context.ClientType);
            _logger.LogInformation(context.Request.Resource);
            next(context);
        }
    }
}