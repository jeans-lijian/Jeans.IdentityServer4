using Jeans.IdentityServer4.Server.Core;
using Jeans.IdentityServer4.Server.Core.Entity;
using Jeans.IdentityServer4.Server.Data.UserMapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Data
{
    public class ObjectDbContext : DbContext, IDbContext
    {
        public ObjectDbContext(DbContextOptions<ObjectDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityMap());
            modelBuilder.ApplyConfiguration(new UserEntityClaimMap());
            modelBuilder.ApplyConfiguration(new UserEntityRoleRelationMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<UserEntityClaim> UserEntityClaims { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserEntityRoleRelation> UserEntityRoleRelations { get; set; }


        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
