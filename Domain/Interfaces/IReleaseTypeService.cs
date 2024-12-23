using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IReleaseTypeService
    {
        Task<List<ReleaseType>> GetAll();
        Task<ReleaseType> GetById(int id);
        Task Create(ReleaseType model);
        Task Update(ReleaseType model);
        Task Delete(int id);
    }
}