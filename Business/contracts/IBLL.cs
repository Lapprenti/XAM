using Entities;
using System;
using System.Collections.Generic;
using System.Text;
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
