using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.Server.Data.Mapping
{
    public class PersistedGrantMap //: IEntityTypeConfiguration<PersistedGrant>
    {
        public void Configure(EntityTypeBuilder<PersistedGrant> builder)
        {
            builder.HasKey(k => k.Key);
            builder.Property(p => p.Key).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Type).HasMaxLength(50).IsRequired();
            builder.Property(p => p.SubjectId).HasMaxLength(200);
            builder.Property(p => p.ClientId).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Data).IsRequired();
        }
    }
}