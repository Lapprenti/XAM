using Business.contracts;
using Entities;
using Newtonsoft.Json.Linq;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.services
{
    public class ErgastAPI
    {
        public async Task<List<Year>> FindSeasonsAsync()
        {
            // Creating refit instance
            var s = RestService.For<IErgastAPI>("http://ergast.com/api/f1");

            // Call route that return all seasons and awaiting response
            JObject response = await s.FindSeasons();

            // Path to all seasons
            JToken token = response["MRData"]["SeasonTable"]["Seasons"];

            // Cast to List of seasons
            var allYears = token.ToObject<List<Year>>();

            return allYears;
        }

        public async Task<List<Driver>> FindDriversForSeasonAsync(int year)
        {
            // Creating refit instance
            var s = RestService.For<IErgastAPI>("http://ergast.com/api/f1");

            // Call route that return all seasons and awaiting response
            JObject response = await s.FindDriversForSeason(year);

            // Path to all drivers
            JToken token = response["MRData"]["DriverTable"]["Drivers"];

            // Cast to List of seasons
            var allDrivers = token.ToObject<List<Driver>>();

            return allDrivers;
        }

        public async Task<List<Constructor>> FindContructorsForSeasonAsync(int year)
        {
            // Creating refit instance
            var s = RestService.For<IErgastAPI>("http://ergast.com/api/f1");

            // Call route that return all seasons and awaiting response
            JObject response = await s.FindConstructorsForSeason(year);

            // Path to all drivers
            JToken token = response["MRData"]["ConstructorTable"]["Constructors"];

            // Cast to List of seasons
            var allConstructors = token.ToObject<List<Constructor>>();

            return allConstructors;
        }
    }
}
