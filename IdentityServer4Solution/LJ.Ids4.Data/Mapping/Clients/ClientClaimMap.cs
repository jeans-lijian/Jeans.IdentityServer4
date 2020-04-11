using LJ.Ids4.Core.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LJ.Ids4.Data.Mapping.Clients
{
    public class ClientClaimMap : IEntityTypeConfiguration<ClientClaim>
    {
        public void Configure(EntityTypeBuilder<ClientClaim> builder)
        {
            builder.ToTable("clientclaims");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Type).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Value).HasMaxLength(250).IsRequired();
        }
    }
}