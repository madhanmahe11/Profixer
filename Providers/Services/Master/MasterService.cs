using Newtonsoft.Json;
using Profixer.Models;
using Profixer.Providers.Interfaces;
using Profixer.Providers.Interfaces.Master;
using Profixer.Response;
using Profixer.Response.City;
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
        public async Task<City> CityList(int countryID, int cityId, string userID)
        {
            string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/GetCity?CountryID={countryID}&CityID={cityId}";
            var response = await _client.Get(apiUrl);
            var data = JsonConvert.DeserializeObject<City>(await response.Content.ReadAsStringAsync());
            return data;
        }

        public async Task<Country> CountryList(int countryID)
        {
            string apiUrl = $"{_config.GetSection("BaseURL").Value}api/Master/GetCountry?CountryID=0";
            var response = await _client.Get(apiUrl);
            var data = JsonConvert.DeserializeObject<Country>(await response.Content.ReadAsStringAsync());
            return data;
        }
    }
}