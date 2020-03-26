using Jeans.IdentityServer4.Server.Core.Entity;
using Jeans.IdentityServer4.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Service
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientService(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                return default(Client);
            }

            return await _clientRepository.Table
                                                          .Include(x => x.ClientClaims)
                                                          .Include(x => x.ClientGrantTypes)
                                                          .Include(x => x.ClientScopes)
                                                          .Include(x => x.ClientSecrets)
                                                          .Include(x => x.ClientPostLogoutRedirectUris)
                                                          .Include(x => x.ClientProperties)
                                                          .Include(x => x.ClientRedirectUris)
                                                          .Include(x => x.ClientCorsOrigins)
                                                          .Include(x => x.ClientIdPRestrictions)
                                                          .FirstOrDefaultAsync(w => w.ClientId == clientId && w.Enabled);
        }
    }
}