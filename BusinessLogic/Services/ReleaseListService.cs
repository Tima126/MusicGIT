using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ReleaseListService : IReleaseListService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ReleaseListService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<ReleaseList>> GetAll()
        {
            return _repositoryWrapper.ReleaseList.FindAll().ToListAsync();
        }

        public Task<ReleaseList> GetById(int id)
        {
            var release = _repositoryWrapper.ReleaseList
                .FindByCondition(x => x.Id == id).First();
            return Task.FromResult(release);
        }

        public Task Create(ReleaseList model)
        {
            _repositoryWrapper.ReleaseList.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ReleaseList model)
        {
            _repositoryWrapper.ReleaseList.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var release = _repositoryWrapper.ReleaseList
                .FindByCondition(x => x.Id == id).First();

            _repositoryWrapper.ReleaseList.Delete(release);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}