using Grpc.Core;
using grpc_test.controllers;
using System;
using Unity;

namespace grpc_test
{
    class Program
    {
        public static void Main()
        {
            var container = new UnityContainer();
            container.RegisterType<Server, Server>();

            var server = container.Resolve<Server>();
            server.Start();
        }
    }
}
