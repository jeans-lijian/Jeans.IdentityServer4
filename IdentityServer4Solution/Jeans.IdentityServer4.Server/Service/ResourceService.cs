using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.Server.Core.Entity;
using Jeans.IdentityServer4.Server.Data;

namespace Jeans.IdentityServer4.Server.Service
{
    public class ResourceService : IResourceService
    {
        private readonly IRepository<ApiResource> _apiResourceRepository;
        public ResourceService(IRepository<ApiResource> apiResourceRepository)
        {
            _apiResourceRepository = apiResourceRepository;
        }

        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }
    }
}
