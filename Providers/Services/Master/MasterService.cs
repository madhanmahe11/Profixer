using Newtonsoft.Json;
using Profixer.Models;
using Profixer.Providers.Interfaces;
using Profixer.Providers.Interfaces.Master;
using Profixer.Response;
using Profixer.Response.Country;
using Profixer.Response.Dashboard;
using Profixer.Response.TicketCount;

namespace Profixer.Providers.Services
{
    public class MasterService : IMaster
    {
        private readonly IConfiguration _config;
        private readonly IClient _client;

        public MasterService(IConfiguration config, IClient client)
        {
            _config = config;
            _client = client;
        }
        public async Task<Response.City.City> CityList(int countryID, int cityId, string userID)
        {
            string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/GetCity?CountryID={countryID}&CityID={cityId}";
            var response = await _client.Get(apiUrl);
            var data = JsonConvert.DeserializeObject<Response.City.City>(await response.Content.ReadAsStringAsync());
            return data;
        }

        public async Task<Models.Master.City> AddCity(Models.Master.City city)
        {
            string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/InsertUpdateCity";
            var data = new
            {
                CityID = city.CityID,
                CityName = city.CityName,
                IsActive = true,
                CountryID = city.CountryID,
                CUID = 1
            };
            // var response = await _client.Post(apiUrl, Newtonsoft.Json.JsonConvert.SerializeObject(data));
            return city;
        }

        public async Task<Country> CountryList(int countryID)
        {
            string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/GetCountry?CountryID={countryID}";
            var response = await _client.Get(apiUrl);
            var data = JsonConvert.DeserializeObject<Country>(await response.Content.ReadAsStringAsync());
            return data;
        }
    }
}