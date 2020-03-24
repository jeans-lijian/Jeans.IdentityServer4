using Jeans.IdentityServer4.Server.Core.Entity;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Service
{
    public interface IUserEntityService
    {
        Task<UserEntity> ValidateAsync(string userName, string password);

        Task<UserEntity> GetUserEntityByNameAsync(string userName);
    }
}