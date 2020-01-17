using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class DeviceFlowCodeMap : IEntityTypeConfiguration<DeviceFlowCode>
    {
        public void Configure(EntityTypeBuilder<DeviceFlowCode> builder)
        {
            builder.HasKey(k => k.UserCode);
            builder.Property(p => p.UserCode).HasMaxLength(200).IsRequired();
            builder.Property(p => p.DeviceCode).HasMaxLength(200).IsRequired();
            builder.Property(p => p.SubjectId).HasMaxLength(200);
            builder.Property(p => p.ClientId).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Data).IsRequired();
        }
    }
}
