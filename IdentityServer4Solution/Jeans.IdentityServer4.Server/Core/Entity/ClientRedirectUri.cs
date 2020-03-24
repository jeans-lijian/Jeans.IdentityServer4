using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 客户重定向Uri
    /// </summary>
    public class ClientRedirectUri : BaseEntity
    {
        public string RedirectUri { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}