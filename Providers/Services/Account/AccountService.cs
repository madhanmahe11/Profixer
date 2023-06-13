using Newtonsoft.Json;
using Profixer.Models;
using Profixer.Providers.Interfaces;
using Profixer.Providers.Interfaces.Account;
using Profixer.Response;
using Profixer.Response.Dashboard;
using Profixer.Response.TicketCount;

namespace Profixer.Providers.Services
{
    public class AccountService : IAccount
    {
        private readonly IConfiguration _config;
        private readonly IClient _client;

        public AccountService(IConfiguration config, IClient client)
        {
            _config = config;
            _client = client;
        }
        public async Task<LoginResponse> Login(LoginByUNandPwd loginData)
        {
            string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Account/UserLogin";
            var response = await _client.Post(apiUrl, Newtonsoft.Json.JsonConvert.SerializeObject(loginData));
            var data = JsonConvert.DeserializeObject<LoginResponse>(await response.Content.ReadAsStringAsync());
            return data;
        }

        public async Task<DashboardResponse> Dashboard(int roleId)
        {
            string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Account/GetMenuWeb?RoleId={roleId}";
            var response = await _client.Get(apiUrl);
            // dynamic data = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            var data = JsonConvert.DeserializeObject<DashboardResponse>(await response.Content.ReadAsStringAsync());
            return data;
        }

        public async Task<TicketCountResponse> TicketCount(int userId)
        {
            string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Supportdesk/GetTicketCount?UserID={userId}&TicketStatusID=0&FromDate=05/01/2023&ToDate=01/01/2024";
            var response = await _client.Get(apiUrl);
            var data = JsonConvert.DeserializeObject<TicketCountResponse>(await response.Content.ReadAsStringAsync());
            return data;
        }
    }
}