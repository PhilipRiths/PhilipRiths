using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class Roles
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string ContactPhone { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
