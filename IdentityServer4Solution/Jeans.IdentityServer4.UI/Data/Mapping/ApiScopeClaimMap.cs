using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Data.Mapping
{
    public class ApiScopeClaimMap : IEntityTypeConfiguration<ApiScopeClaim>
    {
        public void Configure(EntityTypeBuilder<ApiScopeClaim> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Type).HasMaxLength(200).IsRequired();
        }
    }
}
