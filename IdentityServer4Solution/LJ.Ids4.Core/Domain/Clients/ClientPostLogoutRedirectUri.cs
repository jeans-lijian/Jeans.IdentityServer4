namespace LJ.Ids4.Core.Domain.Clients
{
    /// <summary>
    /// 客户Post登录重定向uri
    /// </summary>
    public class ClientPostLogoutRedirectUri : BaseEntity
    {
        public string PostLogoutRedirectUri { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}