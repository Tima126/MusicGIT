using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class GenreList
    {
        public GenreList()
        {
            BandLists = new HashSet<BandList>();
            ReleaseLists = new HashSet<ReleaseList>();
            SongLists = new HashSet<SongList>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BandList> BandLists { get; set; }
        public virtual ICollection<ReleaseList> ReleaseLists { get; set; }
        public virtual ICollection<SongList> SongLists { get; set; }
    }
}
