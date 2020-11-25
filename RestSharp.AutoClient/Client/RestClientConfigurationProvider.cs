using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoRestClient.Processing;
using RestSharp.Authenticators;

namespace AutoRestClient.Client
{
    public class RestClientConfigurationProvider<TClient>
    {
        public Uri BaseUri { get; }
        
        public IAuthenticator Authenticator { get; }
        
        public IWebProxy WebProxy { get; }

        public IEnumerable<object> Middlewares { get; }
        
        public RestClientConfigurationProvider(RestClientConfiguration<TClient> configuration)
        {
            BaseUri = configuration.BaseUri;
            Authenticator = configuration.Authenticator;
            WebProxy = configuration.WebProxy;
            Middlewares = ScanForMiddlewares(configuration, configuration.ValueResolver ?? new DefaultValueResolver());
        }
        
        private static IEnumerable<object> ScanForMiddlewares(RestClientConfiguration<TClient> configuration, IValueResolver valueResolver)
        {
            var middlewares = configuration.Middlewares?.ToList() ?? new List<object>();
            
            middlewares.AddRange(from type in configuration.MiddlewareTypes ?? new List<Type>() select valueResolver.Resolve(type));

            var supportedTypes = new[]
            {
                typeof(IRestCallMiddleware),
                typeof(IRestCallMiddleware<TClient>),
                typeof(IAsyncRestCallMiddleware),
                typeof(IAsyncRestCallMiddleware<TClient>)
            };
            
            var typesFromAssemblies = configuration.AssembliesToScan?
                .Where(x => x.IsDynamic == false)
                .SelectMany(x => x.GetTypes().Where(type => !type.IsAbstract && supportedTypes.Any(supType => supType.IsAssignableFrom(type))));

            if (typesFromAssemblies != null)
                middlewares.AddRange(from type in typesFromAssemblies select valueResolver.Resolve(type));
            
            return middlewares;
        }
    }
}