using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.Server.Core.Entity;
using Jeans.IdentityServer4.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Jeans.IdentityServer4.Server.Service
{
    public class ResourceService : IResourceService
    {
        private readonly IRepository<ApiResource> _apiResourceRepository;
        private readonly IRepository<IdentityResource> _identityResourceRepository;
        public ResourceService(
            IRepository<ApiResource> apiResourceRepository,
            IRepository<IdentityResource> identityResourceRepository)
        {
            _apiResourceRepository = apiResourceRepository;
            _identityResourceRepository = identityResourceRepository;
        }


        public async Task<ApiResource> FindApiResourceAsync(string name)
        {
            var query = _apiResourceRepository.TableNoTracking.Where(w => w.Name == name && w.Enabled);

            return await query.Include(x => x.ApiResourceClaims)
                                        .Include(x => x.ApiResourceProperties)
                                        .Include(x => x.ApiSecrets)
                                        .Include(x => x.ApiScopes)
                                            .ThenInclude(x => x.ApiScopeClaims)
                                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var query = _apiResourceRepository.TableNoTracking.Where(w => scopeNames.Contains(w.Name));
            var results = await query.Include(x => x.ApiResourceClaims)
                                       .Include(x => x.ApiResourceProperties)
                                       .Include(x => x.ApiSecrets)
                                       .Include(x => x.ApiScopes)
                                           .ThenInclude(x => x.ApiScopeClaims)
                                       .ToListAsync();
            return results;
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var query = _identityResourceRepository.TableNoTracking.Where(w => scopeNames.Contains(w.Name));
            var results = await query.Include(x => x.IdentityClaims)
                                                .Include(x => x.IdentityResourceProperties)
                                                .ToListAsync();
            return results;
        }

        public async Task<IEnumerable<ApiResource>> GetAllApiResourceAsync()
        {
            return await _apiResourceRepository.TableNoTracking
                                                                    .Include(x => x.ApiResourceClaims)
                                                                    .Include(x => x.ApiResourceProperties)
                                                                    .Include(x => x.ApiSecrets)
                                                                    .Include(x => x.ApiScopes)
                                                                        .ThenInclude(x => x.ApiScopeClaims)
                                                                    .ToListAsync();
        }

        public async Task<IEnumerable<IdentityResource>> GetAllIdentityResourceAsync()
        {
            return await _identityResourceRepository.TableNoTracking
                                                                           .Include(x => x.IdentityClaims)
                                                                           .Include(x => x.IdentityResourceProperties)
                                                                           .ToListAsync();
        }

    }
}
