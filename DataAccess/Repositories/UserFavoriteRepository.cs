﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;

namespace DataAccess.Repositories
{
    public class UserFavoriteRepository : RepositoryBase<UserFavorite>, IUserFavoriteRepository
    {
        public UserFavoriteRepository(BandList_dbContext repositoryContext)
            : base(repositoryContext) { }
    }
}