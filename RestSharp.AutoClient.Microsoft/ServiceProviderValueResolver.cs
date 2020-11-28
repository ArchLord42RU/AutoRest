using System;
using AutoRestClient.Processing;
using Microsoft.Extensions.DependencyInjection;

namespace AutoRestClient.Microsoft
{
    public class ServiceProviderValueResolver: IValueResolver
    {
        private readonly IServiceProvider _provider;

        public ServiceProviderValueResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        public object Resolve(Type objectType)
        {
            return _provider.GetRequiredService(objectType);
        }
    }
}