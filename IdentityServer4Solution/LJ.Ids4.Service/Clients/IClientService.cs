using LJ.Ids4.Core.Domain.Clients;
using System.Threading.Tasks;

namespace LJ.Ids4.Service.Clients
{
    public interface IClientService
    {
        #region 服务器

        Task<Client> FindClientByIdAsync(string clientId);

        #endregion 服务器
    }
}