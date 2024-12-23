using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class GenreListService : IGenreListService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GenreListService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<GenreList>> GetAll()
        {
            return _repositoryWrapper.GenreList.FindAll().ToListAsync();
        }

        public Task<GenreList> GetById(int id)
        {
            var genre = _repositoryWrapper.GenreList
                .FindByCondition(x => x.Id == id).First();
            return Task.FromResult(genre);
        }

        public Task Create(GenreList model)
        {
            _repositoryWrapper.GenreList.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(GenreList model)
        {
            _repositoryWrapper.GenreList.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var genre = _repositoryWrapper.GenreList
                .FindByCondition(x => x.Id == id).First();

            _repositoryWrapper.GenreList.Delete(genre);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}