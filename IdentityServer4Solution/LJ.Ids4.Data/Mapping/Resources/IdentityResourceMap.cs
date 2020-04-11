using LJ.Ids4.Core.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace LJ.Ids4.Data.Mapping.Resources
{
    public class IdentityResourceMap : IEntityTypeConfiguration<IdentityResource>
    {
        public void Configure(EntityTypeBuilder<IdentityResource> builder)
        {
            builder.ToTable("identityresources");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.DisplayName).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(1000);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(m => m.IdentityResourceProperties).WithOne(o => o.IdentityResource).HasForeignKey(fk => fk.IdentityResourceId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.IdentityClaims).WithOne(o => o.IdentityResource).HasForeignKey(fk => fk.IdentityResourceId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new IdentityResource
                {
                    Name = "openid",
                    DisplayName = "OpenId"
                },
                new IdentityResource
                {
                    Name = "profile",
                    DisplayName = "Profile"
                },
                new IdentityResource
                {
                    Name = "email",
                    DisplayName = "Email"
                },
                new IdentityResource
                {
                    Name = "address",
                    DisplayName = "Address"
                },
                new IdentityResource
                {
                    Name = "phone",
                    DisplayName = "Phone"
                },
                new IdentityResource
                {
                    Name = "offline_access",
                    DisplayName = "OfflineAccess"
                });
        }
    }
}