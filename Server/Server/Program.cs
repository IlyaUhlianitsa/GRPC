using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server;

namespace grpc_test
{
    class Program
    {
        public static async Task Main()
        {
            var host = new HostBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<Server, Server>();
                    services.AddHostedService<HostedService>();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
