using System;
using System.Collections.Generic;

namespace SailingManager.Data
{
    public partial class UserApplicationRoles
    {
        public int ApplicationRoleId { get; set; }
        public int UserId { get; set; }

        public virtual ApplicationRoles ApplicationRole { get; set; }
        public virtual Users User { get; set; }
    }
}
