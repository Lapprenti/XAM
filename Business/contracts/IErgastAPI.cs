using Newtonsoft.Json.Linq;
using Refit;
using System.Threading.Tasks;


namespace Business.contracts
{
    public interface IErgastAPI
    {
        [Get("/seasons.json?limit=100")]
        Task<JObject> FindSeasons();

        [Get("/{year}/drivers.json")]
        Task<JObject> FindDriversForSeason(int year);

        [Get("/{year}/constructors.json")]
        Task<JObject> FindConstructorsForSeason(int year);

    }
}
