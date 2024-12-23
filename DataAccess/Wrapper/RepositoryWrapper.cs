using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Domain.Models;
namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BandList_dbContext _repoContext;

        private IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public RepositoryWrapper(BandList_dbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
