namespace Jeans.IdentityServer4.Server.Core.Entity
{
    public class UserEntityClaimRelation : BaseEntity
    {
        public int UserId { get; set; }
        public UserEntity UserEntity { get; set; }

        public int UserClaimId { get; set; }
        public UserEntityClaim UserEntityClaim { get; set; }
    }
}
