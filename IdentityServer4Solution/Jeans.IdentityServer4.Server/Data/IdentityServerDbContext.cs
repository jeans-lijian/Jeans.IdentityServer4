using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Options;
using Jeans.IdentityServer4.Server.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Data
{
    public class IdentityServerDbContext : DbContext, IDbContext
    {
        private readonly ConfigurationStoreOptions storeOptions;
        public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ConfigureClientContext(storeOptions);
            //modelBuilder.ConfigureResourcesContext(storeOptions);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ApiResource> ApiResources { get; set; }
        public DbSet<Client> Clients { get; set; }


        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
