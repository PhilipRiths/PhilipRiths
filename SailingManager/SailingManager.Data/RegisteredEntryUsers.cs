using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class RegisteredEntryUsers
    {
        public RegisteredEntryUsers()
        {
            Attendants = new HashSet<Attendants>();
            CrewMembers = new HashSet<CrewMembers>();
            Socials = new HashSet<Socials>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int EntryId { get; set; }

        public virtual ICollection<Attendants> Attendants { get; set; }
        public virtual ICollection<CrewMembers> CrewMembers { get; set; }
        public virtual ICollection<Socials> Socials { get; set; }
        public virtual Entries Entry { get; set; }
        public virtual Users User { get; set; }
    }
}
