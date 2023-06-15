using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Profixer.Models.Account;
using Profixer.Models.Master;
using Profixer.Providers.Interfaces.Account;
using Profixer.Providers.Interfaces.Master;

namespace Profixer.Controllers;

public class MasterController : Controller
{
    private readonly ILogger<MasterController> _logger;
    private readonly IMaster _master;
    private readonly IAccount _account;

    public MasterController(ILogger<MasterController> logger, IMaster master, IAccount account)
    {
        _logger = logger;
        _master = master;
        _account = account;
    }


    [HttpGet]
    public async Task<IActionResult> Area()
    {
        return View();
    }

    public async Task<IActionResult> City(int countryID, int cityId, string userID)
    {
        ViewData["UserID"] = userID;
        ViewBag.UserID = userID;
        var cityList = await _master.CityList(countryID, cityId, userID);
        var dashboard = await _account.Dashboard(1);
        var dashboardDatas = new DashboardDatas();
        dashboardDatas.DashboardResponse = dashboard;
        dashboardDatas.CityResponse = cityList;

        var countryList = await _master.CountryList(countryID);
        ViewBag.Countries = new SelectList(countryList?.RtnData, "CountryID", "CountryName");

        if (countryID != 0 && cityId != 0)
        {
            ViewBag.CityName = cityList.RtnData.FirstOrDefault()?.CityName;
            ViewBag.CountryId = countryID;

            return PartialView("AddCity");
        }
        return PartialView("City", dashboardDatas);
    }

    [HttpPost]
    public async Task<IActionResult> AddorEditCity(City city)
    {
        var addCity = await _master.AddCity(city);
        return PartialView("AddCity");
    }
}
