using LJ.Ids4.Core.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LJ.Ids4.Data.Mapping.Clients
{
    public class ClientPropertyMap : IEntityTypeConfiguration<ClientProperty>
    {
        public void Configure(EntityTypeBuilder<ClientProperty> builder)
        {
            builder.ToTable("clientpropertys");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Key).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Value).HasMaxLength(2000).IsRequired();
        }
    }
}