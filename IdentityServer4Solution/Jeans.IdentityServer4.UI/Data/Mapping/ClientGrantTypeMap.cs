using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class ClientGrantTypeMap : IEntityTypeConfiguration<ClientGrantType>
    {
        public void Configure(EntityTypeBuilder<ClientGrantType> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.GrantType).HasMaxLength(250).IsRequired();
        }
    }
}
