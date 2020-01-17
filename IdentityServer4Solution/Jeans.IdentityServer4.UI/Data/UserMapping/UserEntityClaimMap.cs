using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.UserMapping
{
    public class UserEntityClaimMap : IEntityTypeConfiguration<UserEntityClaim>
    {
        public void Configure(EntityTypeBuilder<UserEntityClaim> builder)
        {
            builder.ToTable("T_UserClaim");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Type).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Value).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000);
        }
    }
}
