using Jeans.IdentityServer4.Server.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Service
{
    public interface IResourceService
    {
        Task<ApiResource> FindApiResourceAsync(string name);

        Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames);

        Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames);

        Task<IEnumerable<ApiResource>> GetAllApiResourceAsync();

        Task<IEnumerable<IdentityResource>> GetAllIdentityResourceAsync();
    }
}