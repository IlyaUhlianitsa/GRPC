using System;
using System.Threading.Tasks;
using Grpc.Core;
using grpc_test.controllers;

namespace grpc_test
{
    public class Server
    {
        private Grpc.Core.Server _grpcServer;
        const int Port = 50051;
        public async Task Start()
        {
            try
            {
                _grpcServer = new Grpc.Core.Server
                {
                    Services = { AccountService.BindService(new AccountsImpl()) },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };
                _grpcServer.Start();

                Console.WriteLine($"Accounts server listening on port {Port}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }

        public async Task Stop()
        {
            await _grpcServer.ShutdownAsync();
        }
    }
}