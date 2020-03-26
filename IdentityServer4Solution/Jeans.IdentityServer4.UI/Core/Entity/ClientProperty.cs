using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Core.Entity
{
    /// <summary>
    /// 客户属性
    /// </summary>
    public class ClientProperty : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}