using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jeans.IdentityServer4.Server.Data.UserMapping
{
    public class UserEntityMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("T_User");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.UserName).HasMaxLength(64).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(64).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(1000);

            builder.HasMany(m => m.UserEntityClaims).WithOne(o => o.UserEntity).HasForeignKey(fk => fk.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.UserEntityRoleRelations).WithOne(o => o.UserEntity).HasForeignKey(fk => fk.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
