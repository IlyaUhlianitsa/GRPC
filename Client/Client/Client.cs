using System;
using Grpc.Core;
using Unity;

namespace Client
{
    public class Client
    {
        [Dependency]
        public AccountService.AccountServiceClient AccountServiceClient { get; set; }
        
        [Dependency]
        public Channel Channel { get; set; }
        
        public void Listen()
        {
            try
            {
                EmployeeName empName = AccountServiceClient.GetEmployeeName(new EmployeeNameRequest { EmpId = "1" });

                if (empName == null || string.IsNullOrWhiteSpace(empName.FirstName) || string.IsNullOrWhiteSpace(empName.LastName))
                {
                    Console.WriteLine("Employee not found.");
                }
                else
                {
                    Console.WriteLine($"The employee name is {empName.FirstName} {empName.LastName}.");
                }

                Channel.ShutdownAsync().Wait();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }
    }
}