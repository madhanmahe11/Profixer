using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Profixer.Response;

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

    public async Task<IActionResult> CityList(int countryID, int cityId)
    {
        string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/GetCity?CountryID={countryID}&CityID={cityId}";
        var response = await Get(apiUrl);
        var data = JsonConvert.DeserializeObject<City>(await response.Content.ReadAsStringAsync());
        return View(data);
    }
    public async Task<IActionResult> EditCity(int countryID, int cityID)
    {
        string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/GetCity?CountryID={countryID}&CityID={cityID}";
        var response = await Get(apiUrl);
        var data = JsonConvert.DeserializeObject<City>(await response.Content.ReadAsStringAsync());
        return View(data);
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
