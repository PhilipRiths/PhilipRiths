using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class ApplicationRoles
    {
        public ApplicationRoles()
        {
            UserApplicationRoles = new HashSet<UserApplicationRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<UserApplicationRoles> UserApplicationRoles { get; set; }
    }
}
