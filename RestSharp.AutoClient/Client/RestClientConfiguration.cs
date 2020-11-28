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
}