using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;

namespace DataAccess.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(BandList_dbContext repositoryContext)
            : base(repositoryContext) { }
    }
}