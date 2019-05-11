using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Client
{
    class Program
    {
        static async Task Main()
        {
            var host = new HostBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped(provider => new Channel("127.0.0.1:50051", ChannelCredentials.Insecure));
                    services.AddScoped<AccountService.AccountServiceClient>();
                    services.AddScoped<Client>();
                    services.AddHostedService<HostedService>();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
