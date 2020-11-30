using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using AutoRest.Client.Processing;
using RestSharp.Authenticators;

namespace AutoRest.Client.Client
{
    public class RestClientConfiguration
    {
        public Uri BaseUri { get; set; }
        
        public IAuthenticator Authenticator { get; set; }
        
        public IWebProxy WebProxy { get; set; }
        
        public IValueResolver ValueResolver { get; set; }
        
        internal List<Assembly> AssembliesToScan { get; set; }
        
        internal List<object> Middlewares { get; set; }
        
        internal List<Type> MiddlewareTypes { get; set; }
        
        public RestClientConfiguration()
        {
            AssembliesToScan = new List<Assembly>();
            Middlewares = new List<object>();
            MiddlewareTypes = new List<Type>();
        }

        public void AddMiddleware(object middleware)
        {
            Middlewares.Add(middleware);
        }
        
        public void AddMiddleware(Type middleware)
        {
            MiddlewareTypes.Add(middleware);
        }

        public void AddMiddlewares(IEnumerable<Assembly> assemblies)
        {
            AssembliesToScan.AddRange(assemblies);
        }
    }
    
    public class RestClientConfiguration<TClient> : RestClientConfiguration
    {
        public RestClientConfiguration(RestClientConfiguration baseConfiguration)
        {
            BaseUri = baseConfiguration.BaseUri;
            Authenticator = baseConfiguration.Authenticator;
            WebProxy = baseConfiguration.WebProxy;
            ValueResolver = baseConfiguration.ValueResolver;
            AssembliesToScan = baseConfiguration.AssembliesToScan;
            Middlewares = baseConfiguration.Middlewares;
            MiddlewareTypes = baseConfiguration.MiddlewareTypes;
        }

        public RestClientConfiguration() { }
        
        public RestClientConfigurationProvider<TClient> GetProvider()
        {
            return new RestClientConfigurationProvider<TClient>(this);
        }
    }
}