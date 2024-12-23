using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IReleaseListService
    {
        Task<List<ReleaseList>> GetAll();
        Task<ReleaseList> GetById(int id);
        Task Create(ReleaseList model);
        Task Update(ReleaseList model);
        Task Delete(int id);
    }
}