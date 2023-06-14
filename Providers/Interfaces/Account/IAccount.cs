using Profixer.Models.Account;
using Profixer.Response;
using Profixer.Response.Dashboard;
using Profixer.Response.TicketCount;

namespace Profixer.Providers.Interfaces.Account
{
    public interface IAccount
    {
        Task<LoginResponse> Login(LoginByUNandPwd loginData);
        Task<DashboardResponse> Dashboard(int roleId);
        Task<TicketCountResponse> TicketCount(int roleId);
    }
}