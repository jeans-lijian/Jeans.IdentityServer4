using LJ.Ids4.Core.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LJ.Ids4.Data.Mapping.Clients
{
    public class ClientGrantTypeMap : IEntityTypeConfiguration<ClientGrantType>
    {
        public void Configure(EntityTypeBuilder<ClientGrantType> builder)
        {
            builder.ToTable("clientgranttypes");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.GrantType).HasMaxLength(250).IsRequired();
        }
    }
}