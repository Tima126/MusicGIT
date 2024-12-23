using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace Domain.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IUserFavoriteRepository UserFavorite { get; }
        ISongListRepository SongList { get; }
        IReleaseTypeRepository ReleaseType { get; }
        IReleaseListRepository ReleaseList { get; }
        ILanguageRepository Language { get; }
        IGenreListRepository GenreList { get; }
        ICountryRepository Country { get; }
        IBandMemberRepository BandMember { get; }
        IBandListRepository BandList { get; }

        void Save();
    }
}