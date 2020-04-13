using LJ.Ids4.Core.Domain.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LJ.Ids4.Service.Resources
{
    public interface IResourceService
    {
        #region 服务器

        Task<ApiResource> FindApiResourceAsync(string name);

        Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames);

        Task<IEnumerable<ApiResource>> GetAllApiResourceAsync();

        Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames);

        Task<IEnumerable<IdentityResource>> GetAllIdentityResourceAsync();

        #endregion 服务器
    }
}