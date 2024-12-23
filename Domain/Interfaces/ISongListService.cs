using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ISongListService
    {

        Task<List<SongList>> GetAll();


        Task<SongList> GetById(int id);


        Task Create(SongList model);

        Task Update(SongList model);

        Task Delete(int id);
    }
}