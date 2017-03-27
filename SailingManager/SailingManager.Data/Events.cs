using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class Events
    {
        public Events()
        {
            Races = new HashSet<Races>();
            Socials = new HashSet<Socials>();
        }

        public int Id { get; set; }
        public int RegattaId { get; set; }
        public int No { get; set; }
        public int Name { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Fee { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Races> Races { get; set; }
        public virtual ICollection<Socials> Socials { get; set; }
        public virtual Regattas Regatta { get; set; }
    }
}
