using Microsoft.AspNetCore.Mvc;
using Profixer.Models;
using Profixer.Providers.Interfaces;

namespace Profixer.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAccount _account;

    public AccountController(ILogger<AccountController> logger, IAccount account)
    {
        _account = account;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return PartialView("Login");
    }

    [HttpPost]
    public async Task<IActionResult> Dashboard(LoginByUNandPwd loginData)
    {
        var login = await _account.Login(loginData);
        if ((bool)login?.RtnStatus.Value)
        {
            ViewData["UserID"] = (int)login?.RtnData.UserID;
            var dashboard = await _account.Dashboard((int)login?.RtnData.UserID);
            return View(dashboard);
            // return await Dashboard((int)login?.RtnData.UserID);
        }
        ModelState.AddModelError("", "Incorrect Login details");
        return PartialView("Login", loginData);
    }

    // [HttpGet]
    // public async Task<IActionResult> Dashboard(int roleId)
    // {
    //     ViewData["UserID"] = roleId;
    //     var dashboard = await _account.Dashboard(roleId);
    //     return RedirectToAction("Dashboard", "Account");
    // }

    // public async Task<IActionResult> Dashboard(LoginByUNandPwd loginData)
    // {
    //     string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Account/UserLogin";
    //     var response = await Post(apiUrl, Newtonsoft.Json.JsonConvert.SerializeObject(loginData));
    //     dynamic data = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

    //     if ((bool)data?.RtnStatus.Value)
    //     {
    //         ViewData["UserID"] = (int)data?.RtnData.UserID;
    //         response = await DashboardPage((int)data?.RtnData.RoleID);
    //         data = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
    //         return View();
    //     }
    //     ModelState.AddModelError("", "Incorrect Login details");
    //     return Redirect("");
    // }

    // public async Task<HttpResponseMessage> DashboardPage(int roleId)
    // {
    //     string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Account/GetMenuWeb?RoleId={roleId}";
    //     var response = await Get(apiUrl);
    //     return response;
    // }
}
