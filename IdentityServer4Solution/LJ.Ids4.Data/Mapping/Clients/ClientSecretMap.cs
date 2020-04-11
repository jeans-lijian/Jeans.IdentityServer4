using LJ.Ids4.Core.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LJ.Ids4.Data.Mapping.Clients
{
    public class ClientSecretMap : IEntityTypeConfiguration<ClientSecret>
    {
        public void Configure(EntityTypeBuilder<ClientSecret> builder)
        {
            builder.ToTable("clientsecrets");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Description).HasMaxLength(2000);
            builder.Property(p => p.Value).HasMaxLength(4000).IsRequired();
            builder.Property(p => p.Type).HasMaxLength(250).IsRequired();
        }
    }
}