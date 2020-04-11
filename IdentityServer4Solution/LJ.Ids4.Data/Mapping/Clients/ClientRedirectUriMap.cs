using LJ.Ids4.Core.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LJ.Ids4.Data.Mapping.Clients
{
    public class ClientRedirectUriMap : IEntityTypeConfiguration<ClientRedirectUri>
    {
        public void Configure(EntityTypeBuilder<ClientRedirectUri> builder)
        {
            builder.ToTable("clientredirecturis");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.RedirectUri).HasMaxLength(2000).IsRequired();
        }
    }
}