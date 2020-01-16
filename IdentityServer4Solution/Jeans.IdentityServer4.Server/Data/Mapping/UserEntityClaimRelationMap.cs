using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Data.Mapping
{
    public class UserEntityClaimRelationMap : IEntityTypeConfiguration<UserEntityClaimRelation>
    {
        public void Configure(EntityTypeBuilder<UserEntityClaimRelation> builder)
        {
            builder.ToTable("T_UserClaimRelation");
        }
    }
}
