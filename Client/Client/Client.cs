using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace Client
{
    public class Client
    {
        private readonly AccountService.AccountServiceClient _accountServiceClient;
        private readonly Channel _channel;

        public Client(AccountService.AccountServiceClient accountServiceClient,
            Channel channel)
        {
            _accountServiceClient = accountServiceClient;
            _channel = channel;
        }

        public async Task Start()
        {
            try
            {
                EmployeeName empName = _accountServiceClient.GetEmployeeName(new EmployeeNameRequest { EmpId = "1" });

                if (empName == null || string.IsNullOrWhiteSpace(empName.FirstName) || string.IsNullOrWhiteSpace(empName.LastName))
                {
                    Console.WriteLine("Employee not found.");
                }
                else
                {
                    Console.WriteLine($"The employee name is {empName.FirstName} {empName.LastName}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }
        public async Task Stop()
        {
            await _channel.ShutdownAsync();
        }
    }
}