using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class BandMember
    {
        public BandMember()
        {
            Bands = new HashSet<BandList>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Pseudonym { get; set; }
        public int? BandId { get; set; }
        public bool? IsInBand { get; set; }

        public virtual BandList? Band { get; set; }

        public virtual ICollection<BandList> Bands { get; set; }
    }
}
