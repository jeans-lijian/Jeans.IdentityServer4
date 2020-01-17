using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class ApiResourceMap : IEntityTypeConfiguration<ApiResource>
    {
        public void Configure(EntityTypeBuilder<ApiResource> builder)
        {
            //builder.ToTable("ApiResources");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.DisplayName).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.AllowedAccessTokenSigningAlgorithms).HasMaxLength(100);

            builder.HasMany(m => m.ApiResourceClaims).WithOne(o => o.ApiResource).HasForeignKey(fk => fk.ApiResourceId);
            builder.HasMany(m => m.ApiResourceProperties).WithOne(o => o.ApiResource).HasForeignKey(fk => fk.ApiResourceId);
            builder.HasMany(m => m.ApiScopes).WithOne(o => o.ApiResource).HasForeignKey(fk => fk.ApiResourceId);
            builder.HasMany(m => m.ApiSecrets).WithOne(o => o.ApiResource).HasForeignKey(fk => fk.ApiResourceId);
        }
    }
}
