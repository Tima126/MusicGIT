using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class SongListService : ISongListService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SongListService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<SongList>> GetAll()
        {
            return _repositoryWrapper.SongList.FindAll().ToListAsync();
        }

        public Task<SongList> GetById(int id)
        {
            var song = _repositoryWrapper.SongList
                .FindByCondition(x => x.Id == id).First();
            return Task.FromResult(song);
        }

        public Task Create(SongList model)
        {
            _repositoryWrapper.SongList.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(SongList model)
        {
            _repositoryWrapper.SongList.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var song = _repositoryWrapper.SongList
                .FindByCondition(x => x.Id == id).First();

            _repositoryWrapper.SongList.Delete(song);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}