using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class ApiSecretMap : IEntityTypeConfiguration<ApiSecret>
    {
        public void Configure(EntityTypeBuilder<ApiSecret> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.Value).HasMaxLength(4000).IsRequired();
            builder.Property(p => p.Type).HasMaxLength(250).IsRequired();
        }
    }
}
