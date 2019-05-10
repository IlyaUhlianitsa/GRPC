using Grpc.Core;
using Unity;

namespace Client
{
    class Program
    {
        static void Main()
        {
            var container = new UnityContainer();
            
            container.RegisterInstance(typeof(Channel), new Channel("127.0.0.1:50051", ChannelCredentials.Insecure));
            container.RegisterType<AccountService.AccountServiceClient>();
            container.RegisterType<Client, Client>();

            var client = container.Resolve<Client>();
            client.Listen();
        }
    }
}
