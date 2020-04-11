using LJ.Ids4.Core.Domain.Others;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LJ.Ids4.Data.Mapping.Others
{
    public class PersistedGrantMap //: IEntityTypeConfiguration<PersistedGrant>
    {
        public void Configure(EntityTypeBuilder<PersistedGrant> builder)
        {
            builder.ToTable("persistedgrants");
            builder.HasKey(k => k.Key);
            builder.Property(p => p.Key).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Type).HasMaxLength(50).IsRequired();
            builder.Property(p => p.SubjectId).HasMaxLength(200);
            builder.Property(p => p.ClientId).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Data).IsRequired();
        }
    }
}