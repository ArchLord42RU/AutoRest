using System;
using AutoRestClient.Tests.HttpBin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RestSharp.AutoClient.Examples.Di.Microsoft
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var baseUrl = Configuration.GetValue<string>("HttpBinConfig");
            
            services.AddAutoRestClient<IHttpBinAnythingClient>((provider, client) =>
            {
                client.BaseUri = new Uri("https://httpbin.com");
                client.AddMiddlewares(new[]
                {
                    GetType().Assembly
                });
            });

            services.AddControllers();

            //var mapper = new AutoMapper.Mapper(new MapperConfiguration());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
                endpoints.MapControllers();
            });
        }
    }
}