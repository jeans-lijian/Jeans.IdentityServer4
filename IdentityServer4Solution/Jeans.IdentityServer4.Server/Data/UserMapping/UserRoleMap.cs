using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.Server.Data.UserMapping
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("T_Role");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).HasMaxLength(64).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000);

            builder.HasMany(m => m.UserEntityRoleRelations).WithOne(o => o.UserRole).HasForeignKey(fk => fk.UserRoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}