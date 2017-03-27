using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class Attendants
    {
        public int RegisteredEntryUserId { get; set; }
        public int SocialId { get; set; }
        public int NumberOfFriends { get; set; }

        public virtual RegisteredEntryUsers RegisteredEntryUser { get; set; }
        public virtual Socials Social { get; set; }
    }
}
