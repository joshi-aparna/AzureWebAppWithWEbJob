using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace webjob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?linkid=2250384
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureWebJobs(b =>
                {
                    // b.AddTimers();
                })
                .ConfigureLogging((context, b) =>
                {
                    b.SetMinimumLevel(LogLevel.Information);
                    b.AddConsole();
                });


            var host = builder.Build();
            using (host)
            {
                // await host.RunAsync();
                // The following code will invoke a function called CreateQueueMessage and
                // pass in data (value in this case) to the function
                var jobHost = host.Services.GetService(typeof(IJobHost)) as JobHost;
                if (jobHost == null)
                {
                    throw new InvalidOperationException("Failed to get JobHost service.");
                }
                var inputs = new Dictionary<string, object>
                    {
                        { "id", 0 }
                    };

                await host.StartAsync();
                await jobHost.CallAsync("ScheduledFunction", inputs);
                await host.StopAsync();
            }
        }
    }
}


