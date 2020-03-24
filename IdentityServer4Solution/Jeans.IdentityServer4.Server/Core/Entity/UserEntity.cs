using System.Collections.Generic;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public List<UserEntityClaim> UserEntityClaims { get; set; }
        public List<UserEntityRoleRelation> UserEntityRoleRelations { get; set; }
    }
}