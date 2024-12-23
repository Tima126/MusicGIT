using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class BandList
    {
        public BandList()
        {
            BandMembers = new HashSet<BandMember>();
            ReleaseLists = new HashSet<ReleaseList>();
            SongLists = new HashSet<SongList>();
            UserFavorites = new HashSet<UserFavorite>();
            Members = new HashSet<BandMember>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Genre { get; set; }
        public int Lang { get; set; }
        public int Country { get; set; }

        public virtual Country CountryNavigation { get; set; } = null!;
        public virtual GenreList GenreNavigation { get; set; } = null!;
        public virtual Language LangNavigation { get; set; } = null!;
        public virtual ICollection<BandMember> BandMembers { get; set; }
        public virtual ICollection<ReleaseList> ReleaseLists { get; set; }
        public virtual ICollection<SongList> SongLists { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }

        public virtual ICollection<BandMember> Members { get; set; }
    }
}
