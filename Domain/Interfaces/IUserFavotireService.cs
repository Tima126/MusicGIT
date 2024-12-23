using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserFavoriteService
    {
       
        Task<List<UserFavorite>> GetAll();

        Task<UserFavorite> GetById(int id);

      
        Task Create(UserFavorite model);

       
        Task Update(UserFavorite model);

        Task Delete(int id);
    }
}