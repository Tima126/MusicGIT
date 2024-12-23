using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IBandMemberService
    {
        Task<List<BandMember>> GetAll();
        Task<BandMember> GetById(int id);
        Task Create(BandMember model);
        Task Update(BandMember model);
        Task Delete(int id);
    }
}