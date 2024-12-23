using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;   
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ReleaseTypeService : IReleaseTypeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ReleaseTypeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<ReleaseType>> GetAll()
        {
            return _repositoryWrapper.ReleaseType.FindAll().ToListAsync();
        }

        public Task<ReleaseType> GetById(int id)
        {
            var releaseType = _repositoryWrapper.ReleaseType
                .FindByCondition(x => x.Id == id).First();
            return Task.FromResult(releaseType);
        }

        public Task Create(ReleaseType model)
        {
            _repositoryWrapper.ReleaseType.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ReleaseType model)
        {
            _repositoryWrapper.ReleaseType.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var releaseType = _repositoryWrapper.ReleaseType
                .FindByCondition(x => x.Id == id).First();

            _repositoryWrapper.ReleaseType.Delete(releaseType);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}