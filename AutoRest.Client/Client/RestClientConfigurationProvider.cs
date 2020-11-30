using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoRest.Client.Processing;
using RestSharp.Authenticators;

namespace AutoRest.Client.Client
{
    public class RestClientConfigurationProvider<TClient>
    {
        public RestClientConfiguration<TClient> Configuration { get; }

        public Uri BaseUri { get; }

        public IAuthenticator Authenticator { get; }

        public IWebProxy WebProxy { get; }

        public IEnumerable<object> Middlewares { get; }
        
        public RestClientConfigurationProvider(RestClientConfiguration<TClient> configuration)
        {
            Configuration = configuration;
            BaseUri = configuration.BaseUri;
            Authenticator = configuration.Authenticator;
            WebProxy = configuration.WebProxy;
            Middlewares = ScanForMiddlewares(Configuration, Configuration.ValueResolver ?? new DefaultValueResolver());
        }

        private static IEnumerable<object> ScanForMiddlewares(RestClientConfiguration<TClient> configuration, IValueResolver valueResolver)
        {
            var supportedTypes = new[]
            {
                typeof(RestCallMiddleware),
                typeof(RestCallMiddleware<TClient>),
                typeof(AsyncRestCallMiddleware),
                typeof(AsyncRestCallMiddleware<TClient>)
            };
            
            var middlewares = configuration.Middlewares.Where(x => ImplementOneOf(x.GetType(), supportedTypes)).ToList();
            
            middlewares.AddRange(from type in configuration.MiddlewareTypes
                where ImplementOneOf(type, supportedTypes)
                select valueResolver.Resolve(type));
            
            var typesFromAssemblies = configuration.AssembliesToScan
                .Where(x => x.IsDynamic == false)
                .SelectMany(x => x.GetTypes().Where(type => !type.IsAbstract && ImplementOneOf(type, supportedTypes)));

            middlewares.AddRange(from type in typesFromAssemblies select valueResolver.Resolve(type));

            return middlewares;
        }

        private static bool ImplementOneOf(Type type, IEnumerable<Type> implementTypes)
        {
            if (type?.BaseType?.IsGenericType ?? false)
                return implementTypes.Any(x => x.IsGenericType && x.IsAssignableFrom(type));
            return implementTypes.Any(x => x.IsAssignableFrom(type));
        }
    }
}