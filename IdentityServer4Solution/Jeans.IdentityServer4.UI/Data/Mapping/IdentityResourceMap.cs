using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class IdentityResourceMap : IEntityTypeConfiguration<IdentityResource>
    {
        public void Configure(EntityTypeBuilder<IdentityResource> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.DisplayName).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(1000);

            builder.HasMany(m => m.IdentityResourceProperties).WithOne(o => o.IdentityResource).HasForeignKey(fk => fk.IdentityResourceId);
            builder.HasMany(m => m.IdentityClaims).WithOne(o => o.IdentityResource).HasForeignKey(fk => fk.IdentityResourceId);
        }
    }
}
