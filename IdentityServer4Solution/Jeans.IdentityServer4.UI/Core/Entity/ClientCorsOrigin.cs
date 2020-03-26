using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Core.Entity
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