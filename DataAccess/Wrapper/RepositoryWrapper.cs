using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using DataAccess.Repositories;
using Domain.Models;
using Domain.Wrapper;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BandList_dbContext _repoContext;

        private IUserRepository _user;
        private IUserFavoriteRepository _userFavorite;
        private ISongListRepository _songList;
        private IReleaseTypeRepository _releaseType;
        private IReleaseListRepository _releaseList;
        private ILanguageRepository _language;
        private IGenreListRepository _genreList;
        private ICountryRepository _country;
        private IBandMemberRepository _bandMember;
        private IBandListRepository _bandList;

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

        public IUserFavoriteRepository UserFavorite
        {
            get
            {
                if (_userFavorite == null)
                {
                    _userFavorite = new UserFavoriteRepository(_repoContext);
                }
                return _userFavorite;
            }
        }

        public ISongListRepository SongList
        {
            get
            {
                if (_songList == null)
                {
                    _songList = new SongListRepository(_repoContext);
                }
                return _songList;
            }
        }

        public IReleaseTypeRepository ReleaseType
        {
            get
            {
                if (_releaseType == null)
                {
                    _releaseType = new ReleaseTypeRepository(_repoContext);
                }
                return _releaseType;
            }
        }

        public IReleaseListRepository ReleaseList
        {
            get
            {
                if (_releaseList == null)
                {
                    _releaseList = new ReleaseListRepository(_repoContext);
                }
                return _releaseList;
            }
        }

        public ILanguageRepository Language
        {
            get
            {
                if (_language == null)
                {
                    _language = new LanguageRepository(_repoContext);
                }
                return _language;
            }
        }

        public IGenreListRepository GenreList
        {
            get
            {
                if (_genreList == null)
                {
                    _genreList = new GenreListRepository(_repoContext);
                }
                return _genreList;
            }
        }

        public ICountryRepository Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new CountryRepository(_repoContext);
                }
                return _country;
            }
        }

        public IBandMemberRepository BandMember
        {
            get
            {
                if (_bandMember == null)
                {
                    _bandMember = new BandMemberRepository(_repoContext);
                }
                return _bandMember;
            }
        }

        public IBandListRepository BandList
        {
            get
            {
                if (_bandList == null)
                {
                    _bandList = new BandListRepository(_repoContext);
                }
                return _bandList;
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