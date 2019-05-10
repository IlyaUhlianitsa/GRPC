using System;
using Grpc.Core;
using grpc_test.controllers;

namespace grpc_test
{
    public class Server
    {
        const int Port = 50051;
        public void Start()
        {
            try
            {
                var server = new Grpc.Core.Server
                {
                    Services = { AccountService.BindService(new AccountsImpl()) },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };
                server.Start();

                Console.WriteLine($"Accounts server listening on port {Port}");
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();

                server.ShutdownAsync().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }
    }
}