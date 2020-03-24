using Jeans.IdentityServer4.Server.Core.Entity;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Service
{
    public interface IClientService
    {
        Task<Client> FindClientByIdAsync(string clientId);
    }
}