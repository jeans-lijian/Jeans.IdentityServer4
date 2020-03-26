using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.Server.Data.Mapping
{
    public class ApiResourceClaimMap : IEntityTypeConfiguration<ApiResourceClaim>
    {
        public void Configure(EntityTypeBuilder<ApiResourceClaim> builder)
        {
            builder.ToTable("apiresourceclaims");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Type).HasMaxLength(200).IsRequired();
        }
    }
}