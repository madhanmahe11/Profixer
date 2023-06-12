using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Profixer.Response.City;
using Profixer.Response.Country;

namespace Profixer.Controllers;

public class MasterController : Controller
{
    private readonly ILogger<MasterController> _logger;
    private readonly IConfiguration _config;

    public MasterController(ILogger<MasterController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    // public async Task<IActionResult> GetCityList(int? countryID, int? cityID, int? userID)
    // {
    //     try
    //     {
    //         if (countryID != null && cityID != null)
    //         {
    //             string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/GetCity?CountryID={countryID}&CityID={cityID}";
    //             var response = await Get(apiUrl);
    //             var data = JsonConvert.DeserializeObject<City>(await response.Content.ReadAsStringAsync());
    //             ViewBag.UserID = userID;
    //             return PartialView("AddCity");
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         ModelState.AddModelError("", "Unable to perform opertaion. Try again, and if the problem persists, see your system administrator.");
    //     }
    //     return PartialView("AddCity");
    // }

    public ActionResult GetCityList(int? countryID, int? cityID, int? userID)
    {
        return PartialView("AddCity");
    }

    public async Task<IActionResult> City(int countryID, int cityId, string userID)
    {
        ViewData["UserID"] = userID;
        ViewBag.UserID = userID;
        string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/GetCity?CountryID={countryID}&CityID={cityId}";
        var response = await Get(apiUrl);
        var data = JsonConvert.DeserializeObject<City>(await response.Content.ReadAsStringAsync());
        return View(data);
    }

    public async void GetCities()
    {
        string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/GetCountry?CountryID=0";
        var response = await Get(apiUrl);
        var data = JsonConvert.DeserializeObject<Country>(await response.Content.ReadAsStringAsync());
        ViewBag.Countries = new SelectList(data?.RtnData, "CountryID", "CountryName");
    }
    public async Task<IActionResult> EditCity(int countryID, int cityID)
    {
        string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/GetCity?CountryID={countryID}&CityID={cityID}";
        var response = await Get(apiUrl);
        var data = JsonConvert.DeserializeObject<City>(await response.Content.ReadAsStringAsync());
        return View(data);
    }
    public async Task<IActionResult> AddCity(string userID)
    {
        ViewData["UserID"] = userID;
        string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/GetCountry?CountryID=0";
        var response = await Get(apiUrl);
        var data = JsonConvert.DeserializeObject<Country>(await response.Content.ReadAsStringAsync());
        ViewBag.Countries = new SelectList(data?.RtnData, "CountryID", "CountryName");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCity(string CUID, string cityName, int countryID)
    {
        string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/InsertUpdateCity";
        var data = new
        {
            CityID = 0,
            CityName = cityName,
            IsActive = true,
            CountryID = countryID,
            CUID = Convert.ToInt32(CUID)
        };
        var response = await Post(apiUrl, Newtonsoft.Json.JsonConvert.SerializeObject(data));
        await AddCity(CUID);
        return View();
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
