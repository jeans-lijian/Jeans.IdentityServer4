using IdentityServer4.Models;
using IdentityServer4.Stores;
using Jeans.IdentityServer4.Server.Core.AutoMapper;
using Jeans.IdentityServer4.Server.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.StoreImp
{
    public class JeansResourceStore : IResourceStore
    {
        private readonly IResourceService _resourceService;

        public JeansResourceStore(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public async Task<ApiResource> FindApiResourceAsync(string name)
        {
            Core.Entity.ApiResource entity = await _resourceService.FindApiResourceAsync(name);

            ApiResource apiResource = entity.ToModel();
            apiResource.ApiSecrets = entity.ApiSecrets.Select(s => new Secret
            {
                Type = s.Type,
                Value = s.Value,
                Description = s.Description,
                Expiration = s.Expiration
            }).ToList();
            apiResource.Scopes = entity.ApiScopes.Select(s => new Scope
            {
                Name = s.Name,
                DisplayName = s.DisplayName,
                Description = s.Description,
                Required = s.Required,
                Emphasize = s.Emphasize,
                ShowInDiscoveryDocument = s.ShowInDiscoveryDocument,
                //UserClaims = s.ApiScopeClaims.Select(sc => sc.Type).ToList()
            }).ToList();
            //UserClaims = entity.ApiResourceClaims.Select(s => s.Type).ToList()

            return apiResource;
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            IEnumerable<Core.Entity.ApiResource> entities = await _resourceService.FindApiResourcesByScopeAsync(scopeNames);

            List<ApiResource> results = new List<ApiResource>();
            foreach (var entity in entities)
            {
                ApiResource apiResource = entity.ToModel();
                apiResource.ApiSecrets = entity.ApiSecrets.Select(s => new Secret
                {
                    Type = s.Type,
                    Value = s.Value,
                    Description = s.Description,
                    Expiration = s.Expiration
                }).ToList();
                apiResource.Scopes = entity.ApiScopes.Select(s => new Scope
                {
                    Name = s.Name,
                    DisplayName = s.DisplayName,
                    Description = s.Description,
                    Required = s.Required,
                    Emphasize = s.Emphasize,
                    ShowInDiscoveryDocument = s.ShowInDiscoveryDocument,
                    //UserClaims = s.ApiScopeClaims.Select(sc => sc.Type).ToList()
                }).ToList();
                //UserClaims = entity.ApiResourceClaims.Select(s => s.Type).ToList()

                results.Add(apiResource);
            }

            return results;
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            IEnumerable<Core.Entity.IdentityResource> entities = await _resourceService.FindIdentityResourcesByScopeAsync(scopeNames);

            return entities.Select(x => x.ToModel()).ToList();
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            IEnumerable<Core.Entity.ApiResource> apiResourceEntities = await _resourceService.GetAllApiResourceAsync();
            IEnumerable<Core.Entity.IdentityResource> identityResourceEntities = await _resourceService.GetAllIdentityResourceAsync();

            List<ApiResource> apiResourceResults = new List<ApiResource>();

            foreach (var entity in apiResourceEntities)
            {
                ApiResource apiResource = entity.ToModel();

                apiResource.ApiSecrets = entity.ApiSecrets.Select(s => new Secret
                {
                    Type = s.Type,
                    Value = s.Value,
                    Description = s.Description,
                    Expiration = s.Expiration
                }).ToList();
                apiResource.Scopes = entity.ApiScopes.Select(s => new Scope
                {
                    Name = s.Name,
                    DisplayName = s.DisplayName,
                    Description = s.Description,
                    Required = s.Required,
                    Emphasize = s.Emphasize,
                    ShowInDiscoveryDocument = s.ShowInDiscoveryDocument,
                    //UserClaims = s.ApiScopeClaims.Select(sc => sc.Type).ToList()
                }).ToList();
                // UserClaims = entity.ApiResourceClaims.Select(s => s.Type).ToList()

                apiResourceResults.Add(apiResource);
            }

            List<IdentityResource> identityResourceResults = identityResourceEntities.Select(x => x.ToModel()).ToList();

            return new Resources(identityResourceResults, apiResourceResults);
        }
    }
}