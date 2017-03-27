using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class Results
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int EntryId { get; set; }
        public int Rank { get; set; }
        public double ActualDistance { get; set; }
        public double CalculatedDistance { get; set; }
        public DateTime ActualTime { get; set; }
        public DateTime CalculatedTime { get; set; }
        public string Remark { get; set; }
        public int Points { get; set; }
        public bool Active { get; set; }

        public virtual Entries Entry { get; set; }
        public virtual Races Race { get; set; }
    }
}
