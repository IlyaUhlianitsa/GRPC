using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Server
{
    public class HostedService : IHostedService
    {
        private readonly grpc_test.Server _server;

        public HostedService(grpc_test.Server server)
        {
            _server = server;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _server.Start();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _server.Stop();
        }
    }
}
