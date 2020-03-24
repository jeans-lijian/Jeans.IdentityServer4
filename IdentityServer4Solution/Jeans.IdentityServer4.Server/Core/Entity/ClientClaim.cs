using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 客户声明
    /// </summary>
    public class ClientClaim : BaseEntity
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}