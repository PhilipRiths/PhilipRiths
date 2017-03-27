using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class Socials
    {
        public Socials()
        {
            Attendants = new HashSet<Attendants>();
        }

        public int Id { get; set; }
        public int RegattaId { get; set; }
        public int EventId { get; set; }
        public int RegisteredEntryId { get; set; }
        public int? MaxParticipants { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Attendants> Attendants { get; set; }
        public virtual Events Event { get; set; }
        public virtual Regattas Regatta { get; set; }
        public virtual RegisteredEntryUsers RegisteredEntry { get; set; }
    }
}
