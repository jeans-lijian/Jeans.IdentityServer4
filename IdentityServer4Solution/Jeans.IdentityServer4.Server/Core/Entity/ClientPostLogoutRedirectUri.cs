using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 客户Post登录重定向uri
    /// </summary>
    public class ClientPostLogoutRedirectUri : BaseEntity
    {
        public string PostLogoutRedirectUri { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}