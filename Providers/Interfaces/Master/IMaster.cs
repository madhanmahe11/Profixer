using Profixer.Models;
using Profixer.Response;
using Profixer.Response.Country;
using Profixer.Response.Dashboard;
using Profixer.Response.TicketCount;

namespace Profixer.Providers.Interfaces.Master
{
    public interface IMaster
    {
        Task<Response.City.City> CityList(int countryID, int cityId, string userID);
        Task<Models.Master.City> AddCity(Models.Master.City city);
        Task<Country> CountryList(int countryID);
    }
}