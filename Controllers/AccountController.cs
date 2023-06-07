using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Profixer.Models;
using Profixer.Response;

namespace Profixer.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IConfiguration _config;

    public AccountController(ILogger<AccountController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    public IActionResult Index()
    {
        return PartialView("Login");
    }

    public async Task<IActionResult> Dashboard(LoginByUNandPwd loginInfo)
    {
        string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Account/UserLogin";
        string data = Newtonsoft.Json.JsonConvert.SerializeObject(loginInfo);
        var response = await Post(apiUrl, data);
        string responseContent = await response.Content.ReadAsStringAsync();
        LoginResponse loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent);
        if (loginResponse.RtnStatus)
        {
            DashboardPage(1);
            return PartialView("Dashboard");
        }
        ModelState.AddModelError("", "Incorrect Login details");
        return Index();
    }

    public async void DashboardPage(int roleId)
    {
        string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Account/GetMenuWeb?RoleId={roleId}";
        var response = await Get(apiUrl);
        string getresponseContent = await response.Content.ReadAsStringAsync();
    }

    public async Task<HttpResponseMessage> Post(string apiUrl, string data)
    {
        using (HttpClient client = new HttpClient())
        {
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            return response;
        }
    }

    public async Task<HttpResponseMessage> Get(string apiUrl)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            return response;
        }
    }
}
