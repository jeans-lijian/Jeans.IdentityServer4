using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.Server.Data.Mapping
{
    public class ClientGrantTypeMap : IEntityTypeConfiguration<ClientGrantType>
    {
        public void Configure(EntityTypeBuilder<ClientGrantType> builder)
        {
            builder.ToTable("clientgranttypes");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.GrantType).HasMaxLength(250).IsRequired();
        }
    }
}