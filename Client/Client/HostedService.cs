using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Client
{
    public class HostedService : IHostedService
    {
        private readonly Client _client;

        public HostedService(Client client)
        {
            _client = client;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _client.Start();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.Stop();
        }
    }
}
