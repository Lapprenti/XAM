using Entities;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.contracts
{
    public interface IErgastAPI
    {
        // All seasons - http://ergast.com/api/f1/seasons.json?limit=100
        // Constructors for seasons - http://ergast.com/api/f1/2020/constructors.json
        // Drivers for seasons - http://ergast.com/api/f1/2020/drivers.json

        [Get("/seasons.json")]
        Task<object> FindSeasons();

        [Get("/{year}/drivers.json")]
        Task<List<Driver>> FindDriversForSeason(int year);

    }
}
