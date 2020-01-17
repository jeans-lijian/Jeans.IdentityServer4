using System.Collections.Generic;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    public class UserEntityClaim : BaseEntity
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }


        public int UserId { get; set; }
        public UserEntity UserEntity { get; set; }
    }
}
