using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class ClientPostLogoutRedirectUriMap : IEntityTypeConfiguration<ClientPostLogoutRedirectUri>
    {
        public void Configure(EntityTypeBuilder<ClientPostLogoutRedirectUri> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.PostLogoutRedirectUri).HasMaxLength(2000).IsRequired();
        }
    }
}
