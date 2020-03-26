using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.Server.Data.Mapping
{
    public class ClientClaimMap : IEntityTypeConfiguration<ClientClaim>
    {
        public void Configure(EntityTypeBuilder<ClientClaim> builder)
        {
            builder.ToTable("clientclaims");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Type).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Value).HasMaxLength(250).IsRequired();
        }
    }
}