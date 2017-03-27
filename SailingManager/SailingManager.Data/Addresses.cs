using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class Addresses
    {
        public Addresses()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string AddressType { get; set; }
        public string AddressRow { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
