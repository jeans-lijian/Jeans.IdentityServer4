using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 客户授权类型
    /// </summary>
    public class ClientGrantType : BaseEntity
    {
        public string GrantType { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}