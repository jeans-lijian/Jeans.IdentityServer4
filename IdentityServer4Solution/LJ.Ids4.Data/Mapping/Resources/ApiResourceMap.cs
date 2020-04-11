using LJ.Ids4.Core.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LJ.Ids4.Data.Mapping.Resources
{
    public class ApiResourceMap : IEntityTypeConfiguration<ApiResource>
    {
        public void Configure(EntityTypeBuilder<ApiResource> builder)
        {
            builder.ToTable("apiresources");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.DisplayName).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.AllowedAccessTokenSigningAlgorithms).HasMaxLength(100);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(m => m.ApiResourceClaims).WithOne(o => o.ApiResource).HasForeignKey(fk => fk.ApiResourceId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.ApiResourceProperties).WithOne(o => o.ApiResource).HasForeignKey(fk => fk.ApiResourceId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.ApiScopes).WithOne(o => o.ApiResource).HasForeignKey(fk => fk.ApiResourceId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.ApiSecrets).WithOne(o => o.ApiResource).HasForeignKey(fk => fk.ApiResourceId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}