using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IBandListService
    {
        Task<List<BandList>> GetAll();
        Task<BandList> GetById(int id);
        Task Create(BandList model);
        Task Update(BandList model);
        Task Delete(int id);
    }
}