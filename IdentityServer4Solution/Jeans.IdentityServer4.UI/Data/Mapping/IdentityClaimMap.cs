using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class IdentityClaimMap : IEntityTypeConfiguration<IdentityClaim>
    {
        public void Configure(EntityTypeBuilder<IdentityClaim> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Type).HasMaxLength(200).IsRequired();
        }
    }
}
