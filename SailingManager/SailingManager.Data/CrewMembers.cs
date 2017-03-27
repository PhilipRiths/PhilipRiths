using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class CrewMembers
    {
        public int RegisteredEntryUserId { get; set; }
        public int TeamId { get; set; }
        public bool? ParticipationFlag { get; set; }

        public virtual RegisteredEntryUsers RegisteredEntryUser { get; set; }
        public virtual Teams Team { get; set; }
    }
}
