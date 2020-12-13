using Business.contracts;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.services
{
    public class ErgastAPI
    {
        private IErgastAPI apiService { get; set; }
        public ErgastAPI()
        {
        }
        public List<Driver> FindDriversForSeason(int year)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Year>> FindSeasonsAsync()
        {
            var s = RestService.For<IErgastAPI>("http://ergast.com/api/f1");
            var t = await s.FindSeasons();
            return new List<Year> { };
        }
    }
}
