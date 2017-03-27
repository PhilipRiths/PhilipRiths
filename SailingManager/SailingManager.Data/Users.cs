using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class Users
    {
        public Users()
        {
            Entries = new HashSet<Entries>();
            RegisteredEntryUsers = new HashSet<RegisteredEntryUsers>();
            UserApplicationRoles = new HashSet<UserApplicationRoles>();
        }

        public int Id { get; set; }
        public int AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IceFirstName { get; set; }
        public string IceLastName { get; set; }
        public string IcePhone { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Entries> Entries { get; set; }
        public virtual ICollection<RegisteredEntryUsers> RegisteredEntryUsers { get; set; }
        public virtual ICollection<UserApplicationRoles> UserApplicationRoles { get; set; }
        public virtual Addresses Address { get; set; }
    }
}
