using LJ.Ids4.Core.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LJ.Ids4.Data.Mapping.Resources
{
    public class IdentityResourcePropertyMap : IEntityTypeConfiguration<IdentityResourceProperty>
    {
        public void Configure(EntityTypeBuilder<IdentityResourceProperty> builder)
        {
            builder.ToTable("identityresourcepropertys");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Key).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Value).HasMaxLength(2000).IsRequired();
        }
    }
}