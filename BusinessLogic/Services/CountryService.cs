using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class CountryService : ICountryService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CountryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Country>> GetAll()
        {
            return _repositoryWrapper.Country.FindAll().ToListAsync();
        }

        public Task<Country> GetById(int id)
        {
            var country = _repositoryWrapper.Country
                .FindByCondition(x => x.Id == id).First();
            return Task.FromResult(country);
        }

        public Task Create(Country model)
        {
            _repositoryWrapper.Country.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Country model)
        {
            _repositoryWrapper.Country.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var country = _repositoryWrapper.Country
                .FindByCondition(x => x.Id == id).First();

            _repositoryWrapper.Country.Delete(country);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}