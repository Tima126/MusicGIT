using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class SongList
    {
        public SongList()
        {
            UserFavorites = new HashSet<UserFavorite>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Band { get; set; }
        public int Genre { get; set; }
        public int SongReleaseId { get; set; }

        public virtual BandList BandNavigation { get; set; } = null!;
        public virtual GenreList GenreNavigation { get; set; } = null!;
        public virtual ReleaseList SongRelease { get; set; } = null!;
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
    }
}
