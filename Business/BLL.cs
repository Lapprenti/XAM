using Business.contracts;
using Business.services;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class BLL : IBLL
    {
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
