using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class ClientRedirectUriMap : IEntityTypeConfiguration<ClientRedirectUri>
    {
        public void Configure(EntityTypeBuilder<ClientRedirectUri> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.RedirectUri).HasMaxLength(2000).IsRequired();
        }
    }
}
