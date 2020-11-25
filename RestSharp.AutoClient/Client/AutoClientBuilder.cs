﻿using System;
using AutoRestClient.Interceptors;
using Castle.DynamicProxy;

namespace AutoRestClient.Client
{
    public class AutoClientBuilder<TClient> where TClient : class
    {
        private Func<RestClientConfiguration<TClient>> _configurationProvider;
        
        public TClient Build()
        {
            var proxy = new ProxyGenerator();

            var configuration = _configurationProvider?.Invoke() ??
                                throw new InvalidOperationException("Cannot create client without options");
            
            return proxy.CreateInterfaceProxyWithoutTarget<TClient>(new IInterceptor[]
            {
                new RestSharpInterceptor<TClient>(new RestClientConfigurationProvider<TClient>(configuration)),
            });
        }

        public AutoClientBuilder<TClient> WithConfiguration(Action<RestClientConfiguration<TClient>> configurationAction)
        {
            _configurationProvider = () =>
            {
                var config = new RestClientConfiguration<TClient>();
                configurationAction(config);
                return config;
            };
            return this;
        }
        
        public AutoClientBuilder<TClient> WithConfiguration(RestClientConfiguration<TClient> configuration)
        {
            _configurationProvider = () => configuration;
            return this;
        }
    }
}