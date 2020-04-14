﻿using LJ.Ids4.Core.Domain.Resources;
using LJ.Ids4.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LJ.Ids4.Service.Resources
{
    public class ResourceService : IResourceService
    {
        private readonly IIds4Repository<ApiResource> _apiResourceRepository;
        private readonly IIds4Repository<IdentityResource> _identityResourceRepository;

        public ResourceService(
            IIds4Repository<ApiResource> apiResourceRepository,
            IIds4Repository<IdentityResource> identityResourceRepository)
        {
            _apiResourceRepository = apiResourceRepository;
            _identityResourceRepository = identityResourceRepository;
        }

        #region 服务器

        public async Task<ApiResource> FindApiResourceAsync(string name)
        {
            var query = _apiResourceRepository.Table.Where(w => w.Name == name);

            return await query.Include(x => x.ApiResourceClaims)
                                        .Include(x => x.ApiResourceProperties)
                                        .Include(x => x.ApiSecrets)
                                        .Include(x => x.ApiScopes)
                                          .ThenInclude(x => x.ApiScopeClaims)
                                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var query = _apiResourceRepository.Table.Where(w => w.ApiScopes.Any(a => scopeNames.Contains(a.Name)));
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
            var query = _identityResourceRepository.Table.Where(w => scopeNames.Contains(w.Name));
            var results = await query.Include(x => x.IdentityClaims).Include(x => x.IdentityResourceProperties).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<ApiResource>> GetAllApiResourceAsync()
        {
            return await _apiResourceRepository.Table.Include(x => x.ApiResourceClaims)
                                                                    .Include(x => x.ApiResourceProperties)
                                                                    .Include(x => x.ApiSecrets)
                                                                    .Include(x => x.ApiScopes)
                                                                        .ThenInclude(x => x.ApiScopeClaims)
                                                                    .ToListAsync();
        }

        public async Task<IEnumerable<IdentityResource>> GetAllIdentityResourceAsync()
        {
            return await _identityResourceRepository.Table
                            .Include(x => x.IdentityClaims).Include(x => x.IdentityResourceProperties).ToListAsync();
        }

        #endregion 服务器
    }
}