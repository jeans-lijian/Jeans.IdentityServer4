using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class ClientIdPRestrictionMap : IEntityTypeConfiguration<ClientIdPRestriction>
    {
        public void Configure(EntityTypeBuilder<ClientIdPRestriction> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Provider).HasMaxLength(200).IsRequired();
        }
    }
}
