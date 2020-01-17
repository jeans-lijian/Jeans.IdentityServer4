namespace Jeans.IdentityServer4.UI.Core.Entity
{
    public class UserEntityRoleRelation : BaseEntity
    {
        public int UserId { get; set; }
        public UserEntity UserEntity { get; set; }

        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}
