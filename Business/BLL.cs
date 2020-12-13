using Business.contracts;
using Business.services;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class BLL : IBLL
    {
        // All seasons - http://ergast.com/api/f1/seasons.json?limit=100
        // Constructors for seasons - http://ergast.com/api/f1/2020/constructors.json
        // Drivers for seasons - http://ergast.com/api/f1/2020/drivers.json

        public ErgastAPI apiService { get; set; }

        public BLL()
        {
            apiService = new ErgastAPI();
        }

        public async Task<List<Constructor>> GetAllContructorsForSpecificYear(int year)
        {
            return await apiService.FindContructorsForSeasonAsync(year);
        }

        public async Task<List<Driver>> GetAllDriverForSpecificYear(int year)
        {
            return await apiService.FindDriversForSeasonAsync(year);
        }

        public async Task<List<Year>> GetAllSeasons()
        {
            return await apiService.FindSeasonsAsync();
        }
    }
}
