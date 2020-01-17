using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Core.Entity
{
    /// <summary>
    /// 客户秘钥
    /// </summary>
    public class ClientSecret: BaseEntity
    {
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; } = "SharedSecret";
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
