using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Data.Mapping
{
    public class ApiResourcePropertyMap : IEntityTypeConfiguration<ApiResourceProperty>
    {
        public void Configure(EntityTypeBuilder<ApiResourceProperty> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Key).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Value).HasMaxLength(2000).IsRequired();
        }
    }
}
