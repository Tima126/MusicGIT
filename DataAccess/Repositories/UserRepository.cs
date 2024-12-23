using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(BandList_dbContext repositoryContext)
            : base(repositoryContext) { }
    }
}
