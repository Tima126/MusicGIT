using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICountryService
    {
        Task<List<Country>> GetAll();
        Task<Country> GetById(int id);
        Task Create(Country model);
        Task Update(Country model);
        Task Delete(int id);
    }
}