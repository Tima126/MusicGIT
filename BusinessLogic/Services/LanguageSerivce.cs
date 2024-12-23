using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class LanguageService : ILanguageService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public LanguageService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Language>> GetAll()
        {
            return _repositoryWrapper.Language.FindAll().ToListAsync();
        }

        public Task<Language> GetById(int id)
        {
            var language = _repositoryWrapper.Language
                .FindByCondition(x => x.Id == id).First();
            return Task.FromResult(language);
        }

        public Task Create(Language model)
        {
            _repositoryWrapper.Language.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Language model)
        {
            _repositoryWrapper.Language.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var language = _repositoryWrapper.Language
                .FindByCondition(x => x.Id == id).First();

            _repositoryWrapper.Language.Delete(language);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}