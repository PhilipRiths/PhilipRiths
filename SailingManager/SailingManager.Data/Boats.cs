using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class Boats
    {
        public int Id { get; set; }
        public int SailingNo { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Handicap { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
