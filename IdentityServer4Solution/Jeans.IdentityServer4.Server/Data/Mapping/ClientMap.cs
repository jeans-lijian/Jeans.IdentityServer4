using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.Server.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clients");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.ClientId).HasMaxLength(200).IsRequired();
            builder.Property(p => p.ProtocolType).HasMaxLength(200).IsRequired();
            builder.Property(p => p.ClientName).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.ClientUri).HasMaxLength(2000);
            builder.Property(p => p.LogoUri).HasMaxLength(2000);
            builder.Property(p => p.FrontChannelLogoutUri).HasMaxLength(2000);
            builder.Property(p => p.BackChannelLogoutUri).HasMaxLength(2000);
            builder.Property(p => p.AllowedIdentityTokenSigningAlgorithms).HasMaxLength(100);
            builder.Property(p => p.ClientClaimsPrefix).HasMaxLength(200);
            builder.Property(p => p.PairWiseSubjectSalt).HasMaxLength(200);
            builder.Property(p => p.UserCodeType).HasMaxLength(100);

            builder.HasMany(m => m.ClientClaims).WithOne(o => o.Client).HasForeignKey(fk => fk.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.ClientCorsOrigins).WithOne(o => o.Client).HasForeignKey(fk => fk.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.ClientGrantTypes).WithOne(o => o.Client).HasForeignKey(fk => fk.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.ClientProperties).WithOne(o => o.Client).HasForeignKey(fk => fk.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.ClientRedirectUris).WithOne(o => o.Client).HasForeignKey(fk => fk.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.ClientScopes).WithOne(o => o.Client).HasForeignKey(fk => fk.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.ClientSecrets).WithOne(o => o.Client).HasForeignKey(fk => fk.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.ClientIdPRestrictions).WithOne(o => o.Client).HasForeignKey(fk => fk.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.ClientPostLogoutRedirectUris).WithOne(o => o.Client).HasForeignKey(fk => fk.ClientId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}