using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    public class UserRole : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }


        public List<UserEntityRoleRelation> UserEntityRoleRelations { get; set; }
    }
}
