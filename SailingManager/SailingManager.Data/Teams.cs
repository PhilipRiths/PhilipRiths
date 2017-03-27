using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class Teams
    {
        public Teams()
        {
            CrewMembers = new HashSet<CrewMembers>();
        }

        public int Id { get; set; }
        public int EntryId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<CrewMembers> CrewMembers { get; set; }
        public virtual Entries Entry { get; set; }
    }
}
