using LJ.Ids4.Core.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LJ.Ids4.Data.Mapping.Clients
{
    public class ClientIdPRestrictionMap : IEntityTypeConfiguration<ClientIdPRestriction>
    {
        public void Configure(EntityTypeBuilder<ClientIdPRestriction> builder)
        {
            builder.ToTable("clientidprestrictions");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Provider).HasMaxLength(200).IsRequired();
        }
    }
}