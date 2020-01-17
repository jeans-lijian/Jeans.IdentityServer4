using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.Server.Data.UserMapping
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
