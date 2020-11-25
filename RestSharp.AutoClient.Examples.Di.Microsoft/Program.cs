using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RestSharp.AutoClient.Examples.Di.Microsoft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            
            /*var serviceCollection = new ServiceCollection();

            var provider = serviceCollection.BuildServiceProvider();

            var client = provider.GetRequiredService<ILdeClient>();*/
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}