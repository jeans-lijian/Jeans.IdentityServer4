using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 客户跨域
    /// </summary>
    public class ClientCorsOrigin : BaseEntity
    {
        public string Origin { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}