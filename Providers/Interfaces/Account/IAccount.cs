using Profixer.Models;
using Profixer.Response;
using Profixer.Response.Dashboard;

namespace Profixer.Providers.Interfaces
{
    public interface IAccount
    {
        Task<LoginResponse> Login(LoginByUNandPwd loginData);
        Task<DashboardResponse> Dashboard(int roleId);
    }
}