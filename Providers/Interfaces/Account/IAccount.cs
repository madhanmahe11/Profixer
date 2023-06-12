using Profixer.Models;
using Profixer.Response.Dashboard;

namespace Profixer.Providers.Interfaces
{
    public interface IAccount
    {
        Task<dynamic> Login(LoginByUNandPwd loginData);
        Task<DashboardResponse> Dashboard(int roleId);
    }
}