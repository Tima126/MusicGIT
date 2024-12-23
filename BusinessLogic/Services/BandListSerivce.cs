using Domain.Interfaces;
using Domain.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class BandListService : IBandListService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BandListService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<BandList>> GetAll()
        {
            return _repositoryWrapper.BandList.FindAll().ToListAsync();
        }

        public Task<BandList> GetById(int id)
        {
            var band = _repositoryWrapper.BandList
                .FindByCondition(x => x.Id == id).First();
            return Task.FromResult(band);
        }

        public Task Create(BandList model)
        {
            _repositoryWrapper.BandList.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(BandList model)
        {
            _repositoryWrapper.BandList.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var band = _repositoryWrapper.BandList
                .FindByCondition(x => x.Id == id).First();

            _repositoryWrapper.BandList.Delete(band);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}