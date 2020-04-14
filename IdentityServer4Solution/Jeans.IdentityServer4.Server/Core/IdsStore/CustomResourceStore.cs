using IdentityServer4.Models;
using IdentityServer4.Stores;
using Jeans.IdentityServer4.Server.Core.AutoMapper;
using LJ.Ids4.Service.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Core.IdsStore
{
    public class CustomResourceStore : IResourceStore
    {
        private readonly IResourceService _resourceService;

        public CustomResourceStore(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public async Task<ApiResource> FindApiResourceAsync(string name)
        {
            var entity = await _resourceService.FindApiResourceAsync(name);

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
                UserClaims = s.ApiScopeClaims.Select(sc => sc.Type).ToList()
            }).ToList();
            apiResource.UserClaims = entity.ApiResourceClaims.Select(s => s.Type).ToList();
            apiResource.Properties = entity.ApiResourceProperties.ToDictionary(p => p.Key, p => p.Value);

            return apiResource;
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            IEnumerable<LJ.Ids4.Core.Domain.Resources.ApiResource> entities = await _resourceService.FindApiResourcesByScopeAsync(scopeNames);

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
                    UserClaims = s.ApiScopeClaims.Select(sc => sc.Type).ToList()
                }).ToList();
                apiResource.UserClaims = entity.ApiResourceClaims.Select(s => s.Type).ToList();
                apiResource.Properties = entity.ApiResourceProperties.ToDictionary(p => p.Key, p => p.Value);

                results.Add(apiResource);
            }

            return results;
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            IEnumerable<LJ.Ids4.Core.Domain.Resources.IdentityResource> entities = await _resourceService.FindIdentityResourcesByScopeAsync(scopeNames);

            List<IdentityResource> results = new List<IdentityResource>();
            foreach (var entity in entities)
            {
                IdentityResource identityResource = entity.ToModel();
                identityResource.UserClaims = entity.IdentityClaims.Select(s => s.Type).ToList();
                identityResource.Properties = entity.IdentityResourceProperties.ToDictionary(p => p.Key, p => p.Value);

                results.Add(identityResource);
            }

            return results;
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            IEnumerable<LJ.Ids4.Core.Domain.Resources.ApiResource> apiResourceEntities = await _resourceService.GetAllApiResourceAsync();
            IEnumerable<LJ.Ids4.Core.Domain.Resources.IdentityResource> identityResourceEntities = await _resourceService.GetAllIdentityResourceAsync();

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
                    UserClaims = s.ApiScopeClaims.Select(sc => sc.Type).ToList()
                }).ToList();
                apiResource.UserClaims = entity.ApiResourceClaims.Select(s => s.Type).ToList();
                apiResource.Properties = entity.ApiResourceProperties.ToDictionary(p => p.Key, p => p.Value);

                apiResourceResults.Add(apiResource);
            }

            List<IdentityResource> identityResourceResults = identityResourceEntities.Select(x => x.ToModel()).ToList();

            return new Resources(identityResourceResults, apiResourceResults);
        }
    }
}