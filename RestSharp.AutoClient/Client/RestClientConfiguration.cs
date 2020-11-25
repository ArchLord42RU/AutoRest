using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using AutoRestClient.Processing;
using RestSharp.Authenticators;

namespace AutoRestClient.Client
{
    public class RestClientConfiguration<TClient>
    {
        public Uri BaseUri { get; set; }
        
        public IAuthenticator Authenticator { get; set; }
        
        public IWebProxy WebProxy { get; set; }
        
        public IValueResolver ValueResolver { get; set; }
        
        internal List<Assembly> AssembliesToScan { get; private set; }
        
        internal List<object> Middlewares { get; private set; }
        
        internal List<Type> MiddlewareTypes { get; private set; }
        
        public void AddMiddleware(object middleware)
        {
            var middlewares = Middlewares ?? new List<object>();
            middlewares.Add(middleware);
        }
        
        public void AddMiddleware(Type middleware)
        {
            var middlewareTypes = MiddlewareTypes ?? new List<Type>();
            middlewareTypes.Add(middleware);
        }

        public void AddMiddlewares(Assembly[] assemblies)
        {
            var assembliesToScan = AssembliesToScan ?? new List<Assembly>();
            assembliesToScan.AddRange(assemblies);
        }
    }
}