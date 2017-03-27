using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class Regattas
    {
        public Regattas()
        {
            Entries = new HashSet<Entries>();
            Events = new HashSet<Events>();
            Races = new HashSet<Races>();
            Socials = new HashSet<Socials>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Fee { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Entries> Entries { get; set; }
        public virtual ICollection<Events> Events { get; set; }
        public virtual ICollection<Races> Races { get; set; }
        public virtual ICollection<Socials> Socials { get; set; }
    }
}
