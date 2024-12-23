﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;

namespace DataAccess.Repositories
{
    public class SongListRepository : RepositoryBase<SongList>, ISongListRepository
    {
        public SongListRepository(BandList_dbContext repositoryContext)
            : base(repositoryContext) { }
    }
}