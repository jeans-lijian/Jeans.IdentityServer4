using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class ClientClaimMap : IEntityTypeConfiguration<ClientClaim>
    {
        public void Configure(EntityTypeBuilder<ClientClaim> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Type).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Value).HasMaxLength(250).IsRequired();
        }
    }
}
