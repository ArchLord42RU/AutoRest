using System;
using AutoRest.Client.Proxy;
using Castle.DynamicProxy;

namespace AutoRest.Client.Client
{
    public class AutoRestClientBuilder<TClient> where TClient : class
    {
        private Func<RestClientConfiguration<TClient>> _configurationProvider;
        
        public TClient Build()
        {
            var proxy = new ProxyGenerator();

            var configuration = _configurationProvider?.Invoke() ??
                                throw new InvalidOperationException("Cannot create client without options");
            
            return proxy.CreateInterfaceProxyWithoutTarget<TClient>(new IInterceptor[]
            {
                new RestSharpInterceptor<TClient>(configuration.GetProvider()),
            });
        }

        public AutoRestClientBuilder<TClient> WithConfiguration(Action<RestClientConfiguration<TClient>> configurationAction)
        {
            _configurationProvider = () =>
            {
                var config = new RestClientConfiguration<TClient>();
                configurationAction(config);
                return config;
            };
            return this;
        }
        
        public AutoRestClientBuilder<TClient> WithConfiguration(RestClientConfiguration<TClient> configuration)
        {
            _configurationProvider = () => configuration;
            return this;
        }
    }
}