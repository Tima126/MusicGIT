using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ReleaseList
    {
        public ReleaseList()
        {
            SongLists = new HashSet<SongList>();
            UserFavorites = new HashSet<UserFavorite>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Band { get; set; }
        public int Genre { get; set; }
        public int Type { get; set; }
        public int Year { get; set; }
        public int SongAmmount { get; set; }

        public virtual BandList BandNavigation { get; set; } = null!;
        public virtual GenreList GenreNavigation { get; set; } = null!;
        public virtual ReleaseType TypeNavigation { get; set; } = null!;
        public virtual ICollection<SongList> SongLists { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
    }
}
