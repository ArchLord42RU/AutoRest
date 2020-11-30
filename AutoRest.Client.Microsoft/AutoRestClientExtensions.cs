using System;
using System.Linq;
using AutoRest.Client.Client;
using AutoRest.Client.Microsoft;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoRestClientExtensions
    {
        /// <summary>
        /// Adds auto rest client to DI container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <typeparam name="TClient"></typeparam>
        /// <returns></returns>
        public static IServiceCollection AddAutoRestClient<TClient>(this IServiceCollection services, 
            Action<IServiceProvider, RestClientConfiguration<TClient>> configuration)
            where TClient : class
        {
            if (services.Any(sd => sd.ServiceType == typeof(TClient)))
                return services;
            
            services.AddOptions<RestClientConfiguration<TClient>>().Configure<IServiceProvider>((clientConfiguration, provider) 
                => configuration(provider, clientConfiguration));

            services.AddSingleton(provider =>
            {
                var config = provider.GetRequiredService<IOptions<RestClientConfiguration<TClient>>>().Value;
                config.ValueResolver ??= new ServiceProviderValueResolver(provider);
                return new RestClientConfigurationProvider<TClient>(config);
            });

            services.AddTransient(provider => new AutoRestClientBuilder<TClient>()
                .WithConfiguration(provider.GetRequiredService<IOptions<RestClientConfiguration<TClient>>>().Value).Build());

            return services;
        }
    }
}