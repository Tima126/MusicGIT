using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserFavoriteService : IUserFavoriteService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserFavoriteService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<UserFavorite>> GetAll()
        {
            return _repositoryWrapper.UserFavorite.FindAll().ToListAsync();
        }

        public Task<UserFavorite> GetById(int id)
        {
            var userFavorite = _repositoryWrapper.UserFavorite
                .FindByCondition(x => x.Id == id).First();
            return Task.FromResult(userFavorite);
        }

        public Task Create(UserFavorite model)
        {
            _repositoryWrapper.UserFavorite.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(UserFavorite model)
        {
            _repositoryWrapper.UserFavorite.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var userFavorite = _repositoryWrapper.UserFavorite
                .FindByCondition(x => x.Id == id).First();

            _repositoryWrapper.UserFavorite.Delete(userFavorite);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}