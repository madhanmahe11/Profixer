using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Profixer.Models;

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

    public async Task<IActionResult> Dashboard(LoginByUNandPwd loginData)
    {
        string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Account/UserLogin";
        var response = await Post(apiUrl, Newtonsoft.Json.JsonConvert.SerializeObject(loginData));
        dynamic data = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

        if ((bool)data?.RtnStatus.Value)
        {
            response = await DashboardPage((int)data?.RtnData.RoleID);
            data = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            return View();
        }
        ModelState.AddModelError("", "Incorrect Login details");
        return Index();
    }

    public async Task<HttpResponseMessage> DashboardPage(int roleId)
    {
        string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Account/GetMenuWeb?RoleId={roleId}";
        var response = await Get(apiUrl);
        return response;
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
