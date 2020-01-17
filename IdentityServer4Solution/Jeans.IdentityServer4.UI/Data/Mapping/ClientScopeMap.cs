using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class ClientScopeMap : IEntityTypeConfiguration<ClientScope>
    {
        public void Configure(EntityTypeBuilder<ClientScope> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Scope).HasMaxLength(200).IsRequired();
        }
    }
}
