using Domain.Interfaces;
using Domain.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class BandMemberService : IBandMemberService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BandMemberService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<BandMember>> GetAll()
        {
            return _repositoryWrapper.BandMember.FindAll().ToListAsync();
        }

        public Task<BandMember> GetById(int id)
        {
            var bandMember = _repositoryWrapper.BandMember
                .FindByCondition(x => x.Id == id).First();
            return Task.FromResult(bandMember);
        }

        public Task Create(BandMember model)
        {
            _repositoryWrapper.BandMember.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(BandMember model)
        {
            _repositoryWrapper.BandMember.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var bandMember = _repositoryWrapper.BandMember
                .FindByCondition(x => x.Id == id).First();

            _repositoryWrapper.BandMember.Delete(bandMember);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}