using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AssessmentDemoWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                    webBuilder.CaptureStartupErrors(true);
                    webBuilder.UseSetting("https_port", "8083");
                    webBuilder.UseStartup("AssessmentDemoWebAPI");
                });
    }
}