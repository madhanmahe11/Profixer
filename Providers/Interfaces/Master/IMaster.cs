using Profixer.Models;
using Profixer.Response;
using Profixer.Response.City;
using Profixer.Response.Country;
using Profixer.Response.Dashboard;
using Profixer.Response.TicketCount;

namespace Profixer.Providers.Interfaces.Master
{
    public interface IMaster
    {
        Task<City> CityList(int countryID, int cityId, string userID);
        Task<Country> CountryList(int countryID);
    }
}