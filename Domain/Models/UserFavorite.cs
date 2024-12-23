using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class UserFavorite
    {
        public int Id { get; set; }
        public int BandId { get; set; }
        public int ReleaseId { get; set; }
        public int SongId { get; set; }
        public string? Review { get; set; }

        public virtual BandList Band { get; set; } = null!;
        public virtual User IdNavigation { get; set; } = null!;
        public virtual ReleaseList Release { get; set; } = null!;
        public virtual SongList Song { get; set; } = null!;
    }
}
