using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.contracts
{
    public interface IBLL
    {
        Task<List<Year>> GetAllSeasons();
        Task<List<Driver>> GetAllDriverForSpecificYear(int year);
        Task<List<Constructor>> GetAllContructorsForSpecificYear(int year);
    }
}
