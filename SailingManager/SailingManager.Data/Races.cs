using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class Races
    {
        public Races()
        {
            Results = new HashSet<Results>();
        }

        public int Id { get; set; }
        public int RegattaId { get; set; }
        public int EventId { get; set; }
        public string EndLocation { get; set; }
        public string Classification { get; set; }
        public int? MaxTeams { get; set; }
        public double MinHandicap { get; set; }
        public double MaxHandicap { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Results> Results { get; set; }
        public virtual Events Event { get; set; }
        public virtual Regattas Regatta { get; set; }
    }
}
