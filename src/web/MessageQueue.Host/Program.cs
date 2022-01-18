using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MessageQueueHost = Microsoft.Extensions.Hosting.Host;

namespace MessageQueue.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            MessageQueueHost.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
