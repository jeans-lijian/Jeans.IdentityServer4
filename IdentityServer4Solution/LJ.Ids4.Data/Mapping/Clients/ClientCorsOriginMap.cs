using LJ.Ids4.Core.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LJ.Ids4.Data.Mapping.Clients
{
    public class ClientCorsOriginMap : IEntityTypeConfiguration<ClientCorsOrigin>
    {
        public void Configure(EntityTypeBuilder<ClientCorsOrigin> builder)
        {
            builder.ToTable("clientcorsorigins");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Origin).HasMaxLength(150).IsRequired();
        }
    }
}