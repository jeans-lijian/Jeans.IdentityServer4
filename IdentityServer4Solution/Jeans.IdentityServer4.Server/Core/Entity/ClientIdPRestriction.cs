using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 客户端限制
    /// </summary>
    public class ClientIdPRestriction : BaseEntity
    {
        public string Provider { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}