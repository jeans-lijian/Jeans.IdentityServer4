using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 客户作用域
    /// </summary>
    public class ClientScope : BaseEntity
    {
        public string Scope { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}