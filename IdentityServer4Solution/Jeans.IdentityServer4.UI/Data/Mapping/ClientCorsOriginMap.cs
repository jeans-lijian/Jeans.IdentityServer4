using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class ClientCorsOriginMap : IEntityTypeConfiguration<ClientCorsOrigin>
    {
        public void Configure(EntityTypeBuilder<ClientCorsOrigin> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Origin).HasMaxLength(150).IsRequired();
        }
    }
}
