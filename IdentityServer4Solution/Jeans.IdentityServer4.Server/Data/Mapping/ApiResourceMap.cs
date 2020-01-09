using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.Server.Data.Mapping
{
    public class ApiResourceMap : IEntityTypeConfiguration<ApiResource>
    {
        public void Configure(EntityTypeBuilder<ApiResource> builder)
        {
            builder.ToTable("ApiResources");

            builder.HasMany(m => m.ApiResourceClaims).WithOne(o => o.ApiResource).HasForeignKey(fk => fk.ApiResourceId);
        }
    }
}
