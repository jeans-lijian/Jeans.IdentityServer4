using IdentityServer4.Models;
using IdentityServer4.Stores;
using Jeans.IdentityServer4.Server.Service;
using System;
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
            if (entity == null)
            {
                return new ApiResource();
            }

            ApiResource apiResource = new ApiResource
            {
                Name = entity.Name,
                Enabled = entity.Enabled,
                DisplayName = entity.DisplayName,
                Description = entity.Description,
                Properties = entity.ApiResourceProperties.ToDictionary(k => k.Key, v => v.Value),
                ApiSecrets = entity.ApiSecrets.Select(s => new Secret
                {
                    Type = s.Type,
                    Value = s.Value.Sha256(),
                    Description = s.Description,
                    Expiration = s.Expiration
                }).ToList(),
                Scopes = entity.ApiScopes.Select(s => new Scope
                {
                    Name = s.Name,
                    DisplayName = s.DisplayName,
                    Description = s.Description,
                    Required = s.Required,
                    Emphasize = s.Emphasize,
                    ShowInDiscoveryDocument = s.ShowInDiscoveryDocument,
                    UserClaims = s.ApiScopeClaims.Select(sc => sc.Type).ToList()
                }).ToList(),
                UserClaims = entity.ApiResourceClaims.Select(s => s.Type).ToList()
            };

            return apiResource;
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            IEnumerable<Core.Entity.ApiResource> entities = await _resourceService.FindApiResourcesByScopeAsync(scopeNames);
            if (entities == null || !entities.Any())
            {
                return new List<ApiResource>();
            }

            List<ApiResource> results = new List<ApiResource>();
            entities.ToList().ForEach(entity =>
            {
                ApiResource apiResource = new ApiResource
                {
                    Name = entity.Name,
                    Enabled = entity.Enabled,
                    DisplayName = entity.DisplayName,
                    Description = entity.Description,
                    Properties = entity.ApiResourceProperties.ToDictionary(k => k.Key, v => v.Value),
                    ApiSecrets = entity.ApiSecrets.Select(s => new Secret
                    {
                        Type = s.Type,
                        Value = s.Value,
                        Description = s.Description,
                        Expiration = s.Expiration
                    }).ToList(),
                    Scopes = entity.ApiScopes.Select(s => new Scope
                    {
                        Name = s.Name,
                        DisplayName = s.DisplayName,
                        Description = s.Description,
                        Required = s.Required,
                        Emphasize = s.Emphasize,
                        ShowInDiscoveryDocument = s.ShowInDiscoveryDocument,
                        UserClaims = s.ApiScopeClaims.Select(sc => sc.Type).ToList()
                    }).ToList(),
                    UserClaims = entity.ApiResourceClaims.Select(s => s.Type).ToList()
                };

                results.Add(apiResource);
            });

            return results;
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            IEnumerable<Core.Entity.IdentityResource> entities = await _resourceService.FindIdentityResourcesByScopeAsync(scopeNames);
            if (entities == null || !entities.Any())
            {
                return new List<IdentityResource>();
            }

            List<IdentityResource> results = new List<IdentityResource>();
            entities.ToList().ForEach(entity =>
            {
                IdentityResource identityResource = new IdentityResource
                {
                    Name = entity.Name,
                    Enabled = entity.Enabled,
                    DisplayName = entity.DisplayName,
                    Description = entity.Description,
                    Properties = entity.IdentityResourceProperties.ToDictionary(k => k.Key, v => v.Value),
                    UserClaims = entity.IdentityClaims.Select(s => s.Type).ToList()
                };

                results.Add(identityResource);
            });

            return results;
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            IEnumerable<Core.Entity.ApiResource> apiResourceEntities = await _resourceService.GetAllApiResourceAsync();
            IEnumerable<Core.Entity.IdentityResource> identityResourceEntities = await _resourceService.GetAllIdentityResourceAsync();

            List<ApiResource> apiResourceResults = new List<ApiResource>();
            List<IdentityResource> identityResourceResults = new List<IdentityResource>();

            apiResourceEntities.ToList().ForEach(entity =>
            {
                ApiResource apiResource = new ApiResource
                {
                    Name = entity.Name,
                    Enabled = entity.Enabled,
                    DisplayName = entity.DisplayName,
                    Description = entity.Description,
                    Properties = entity.ApiResourceProperties.ToDictionary(k => k.Key, v => v.Value),
                    ApiSecrets = entity.ApiSecrets.Select(s => new Secret
                    {
                        Type = s.Type,
                        Value = s.Value,
                        Description = s.Description,
                        Expiration = s.Expiration
                    }).ToList(),
                    Scopes = entity.ApiScopes.Select(s => new Scope
                    {
                        Name = s.Name,
                        DisplayName = s.DisplayName,
                        Description = s.Description,
                        Required = s.Required,
                        Emphasize = s.Emphasize,
                        ShowInDiscoveryDocument = s.ShowInDiscoveryDocument,
                        UserClaims = s.ApiScopeClaims.Select(sc => sc.Type).ToList()
                    }).ToList(),
                    UserClaims = entity.ApiResourceClaims.Select(s => s.Type).ToList()
                };

                apiResourceResults.Add(apiResource);
            });

            identityResourceEntities.ToList().ForEach(entity =>
            {
                IdentityResource identityResource = new IdentityResource
                {
                    Name = entity.Name,
                    Enabled = entity.Enabled,
                    DisplayName = entity.DisplayName,
                    Description = entity.Description,
                    Properties = entity.IdentityResourceProperties.ToDictionary(k => k.Key, v => v.Value),
                    UserClaims = entity.IdentityClaims.Select(s => s.Type).ToList()
                };

                identityResourceResults.Add(identityResource);
            });

            return new Resources(identityResourceResults, apiResourceResults);
        }

    }
}
