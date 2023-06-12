using Newtonsoft.Json;
using Profixer.Models;
using Profixer.Providers.Interfaces;
using Profixer.Response.Dashboard;

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
        public async Task<dynamic> Login(LoginByUNandPwd loginData)
        {
            string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Account/UserLogin";
            var response = await _client.Post(apiUrl, Newtonsoft.Json.JsonConvert.SerializeObject(loginData));
            dynamic data = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
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
    }
}