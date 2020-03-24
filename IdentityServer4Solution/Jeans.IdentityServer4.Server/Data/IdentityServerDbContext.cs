using Jeans.IdentityServer4.Server.Core;
using Jeans.IdentityServer4.Server.Core.Entity;
using Jeans.IdentityServer4.Server.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Jeans.IdentityServer4.Server.Data
{
    public class IdentityServerDbContext : DbContext, IDbContext
    {
        public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApiResourceMap());
            //modelBuilder.ApplyConfiguration(new ApiResourceClaimMap());
            //modelBuilder.ApplyConfiguration(new ApiResourcePropertyMap());
            // modelBuilder.ApplyConfiguration(new ApiScopeClaimMap());
            modelBuilder.ApplyConfiguration(new ApiScopeMap());
            modelBuilder.ApplyConfiguration(new ApiSecretMap());
            //modelBuilder.ApplyConfiguration(new ClientClaimMap());
            //modelBuilder.ApplyConfiguration(new ClientCorsOriginMap());
            modelBuilder.ApplyConfiguration(new ClientGrantTypeMap());
            //modelBuilder.ApplyConfiguration(new ClientIdPRestrictionMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            //modelBuilder.ApplyConfiguration(new ClientPostLogoutRedirectUriMap());
            //modelBuilder.ApplyConfiguration(new ClientPropertyMap());
            //modelBuilder.ApplyConfiguration(new ClientRedirectUriMap());
            modelBuilder.ApplyConfiguration(new ClientScopeMap());
            modelBuilder.ApplyConfiguration(new ClientSecretMap());
            modelBuilder.ApplyConfiguration(new IdentityResourceMap());
            //modelBuilder.ApplyConfiguration(new IdentityResourcePropertyMap());
            //modelBuilder.ApplyConfiguration(new IdentityClaimMap());
            //modelBuilder.ApplyConfiguration(new PersistedGrantMap());
            //modelBuilder.ApplyConfiguration(new DeviceFlowCodeMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ApiResource> ApiResources { get; set; }
        //public DbSet<ApiResourceClaim> ApiResourceClaims { get; set; }
        //public DbSet<ApiResourceProperty> ApiResourceProperties { get; set; }
        public DbSet<ApiScope> ApiScopes { get; set; }
        //public DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }
        public DbSet<ApiSecret> ApiSecrets { get; set; }

        public DbSet<Client> Clients { get; set; }
        //public DbSet<ClientClaim> ClientClaims { get; set; }
        //public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }
        public DbSet<ClientGrantType> ClientGrantTypes { get; set; }
        //public DbSet<ClientProperty> ClientProperties { get; set; }
        //public DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }
        public DbSet<ClientScope> ClientScopes { get; set; }
        public DbSet<ClientSecret> ClientSecrets { get; set; }
        //public DbSet<ClientIdPRestriction> ClientIdPRestrictions { get; set; }
        //public DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }

        public DbSet<IdentityResource> IdentityResources { get; set; }
        //public DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }
        //public DbSet<IdentityClaim> IdentityClaims { get; set; }

        //public DbSet<PersistedGrant> PersistedGrants { get; set; }
        //public DbSet<DeviceFlowCode> DeviceFlowCodes { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
}