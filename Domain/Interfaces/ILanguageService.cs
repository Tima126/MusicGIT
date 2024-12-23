using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ILanguageService
    {
        Task<List<Language>> GetAll();
        Task<Language> GetById(int id);
        Task Create(Language model);
        Task Update(Language model);
        Task Delete(int id);
    }
}