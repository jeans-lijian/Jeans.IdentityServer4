using Jeans.IdentityServer4.Server.Core.Entity;
using Jeans.IdentityServer4.Server.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var query = _apiResourceRepository.Table.Where(w => w.Name == name);

            return await query
                                        .Include(x => x.ApiSecrets)
                                        .Include(x => x.ApiScopes)
                                        //  .ThenInclude(x => x.ApiScopeClaims)
                                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var query = _apiResourceRepository.Table.Where(w => w.ApiScopes.Any(a => scopeNames.Contains(a.Name)));
            var results = await query
                                       .Include(x => x.ApiSecrets)
                                       .Include(x => x.ApiScopes)
                                       .ToListAsync();
            return results;
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var query = _identityResourceRepository.Table.Where(w => scopeNames.Contains(w.Name));
            var results = await query.ToListAsync();
            return results;
        }

        public async Task<IEnumerable<ApiResource>> GetAllApiResourceAsync()
        {
            return await _apiResourceRepository.Table
                                                                    .Include(x => x.ApiSecrets)
                                                                    .Include(x => x.ApiScopes)
                                                                    .ToListAsync();
        }

        public async Task<IEnumerable<IdentityResource>> GetAllIdentityResourceAsync()
        {
            return await _identityResourceRepository.Table.ToListAsync();
        }
    }
}