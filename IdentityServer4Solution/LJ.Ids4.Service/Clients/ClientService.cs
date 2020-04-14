using LJ.Ids4.Core.Domain.Clients;
using LJ.Ids4.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LJ.Ids4.Service.Clients
{
    public class ClientService : IClientService
    {
        private readonly IIds4Repository<Client> _clientRepository;

        public ClientService(IIds4Repository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        #region 服务器

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

        #endregion 服务器
    }
}