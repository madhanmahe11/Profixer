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

    public async Task<IActionResult> Dashboard(LoginByUNandPwd logininfo)
    {
        string apiUrl = _config.GetSection("BaseURL").Value + "api/Account/UserLogin";

        string data = Newtonsoft.Json.JsonConvert.SerializeObject(logininfo);
        using (HttpClient client = new HttpClient())
        {
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                LoginResponse resposneData = JsonSerializer.Deserialize<LoginResponse>(responseContent);
                if (resposneData.RtnStatus)
                {
                    return PartialView("Dashboard");
                }
            }
            return Index();
        }
    }

    // private async void GetResponse(string address)
    // {
    //     var client = new HttpClient();
    //     HttpResponseMessage response = await client.GetAsync(address);
    //     response.EnsureSuccessStatusCode();
    //     // result = await response.Content.ReadAsStringAsync();
    // }
}
