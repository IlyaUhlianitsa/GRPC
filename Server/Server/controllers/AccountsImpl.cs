using Grpc.Core;
using grpc_test.modules;
using System.Threading.Tasks;

namespace grpc_test.controllers
{
    class AccountsImpl : AccountService.AccountServiceBase
    {
        // Server side handler of the GetEmployeeName RPC
        public override Task<EmployeeName> GetEmployeeName(EmployeeNameRequest request, ServerCallContext context)
        {
            EmployeeData empData = new EmployeeData();
            return Task.FromResult(empData.GetEmployeeName(request));
        }
    }
}
