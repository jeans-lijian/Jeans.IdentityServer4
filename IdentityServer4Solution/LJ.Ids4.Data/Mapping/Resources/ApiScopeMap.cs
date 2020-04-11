using LJ.Ids4.Core.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LJ.Ids4.Data.Mapping.Resources
{
    public class ApiScopeMap : IEntityTypeConfiguration<ApiScope>
    {
        public void Configure(EntityTypeBuilder<ApiScope> builder)
        {
            builder.ToTable("apiscopes");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.DisplayName).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(1000);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(m => m.ApiScopeClaims).WithOne(o => o.ApiScope).HasForeignKey(fk => fk.ApiScopeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}