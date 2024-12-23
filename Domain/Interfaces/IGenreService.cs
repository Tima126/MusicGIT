using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IGenreListService
    {
        Task<List<GenreList>> GetAll();
        Task<GenreList> GetById(int id);
        Task Create(GenreList model);
        Task Update(GenreList model);
        Task Delete(int id);
    }
}