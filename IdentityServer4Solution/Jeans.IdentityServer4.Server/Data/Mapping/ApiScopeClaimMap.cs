using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.Server.Data.Mapping
{
    public class ApiScopeClaimMap : IEntityTypeConfiguration<ApiScopeClaim>
    {
        public void Configure(EntityTypeBuilder<ApiScopeClaim> builder)
        {
            builder.ToTable("apiscopeclaims");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Type).HasMaxLength(200).IsRequired();
        }
    }
}