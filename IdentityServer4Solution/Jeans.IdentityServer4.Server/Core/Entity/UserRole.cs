using System.Collections.Generic;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    public class UserRole : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<UserEntityRoleRelation> UserEntityRoleRelations { get; set; }
    }
}