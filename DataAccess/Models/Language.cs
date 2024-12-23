using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Language
    {
        public Language()
        {
            BandLists = new HashSet<BandList>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BandList> BandLists { get; set; }
    }
}
