using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.UserMapping
{
    public class UserEntityRoleRelationMap : IEntityTypeConfiguration<UserEntityRoleRelation>
    {
        public void Configure(EntityTypeBuilder<UserEntityRoleRelation> builder)
        {
            builder.ToTable("T_UserRoleRelation");
            builder.HasKey(k => k.Id);
        }
    }
}
