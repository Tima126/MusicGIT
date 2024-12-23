using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ReleaseType
    {
        public ReleaseType()
        {
            ReleaseLists = new HashSet<ReleaseList>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<ReleaseList> ReleaseLists { get; set; }
    }
}
