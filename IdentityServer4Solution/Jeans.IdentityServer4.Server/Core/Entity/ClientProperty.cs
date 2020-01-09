using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 客户属性
    /// </summary>
    public class ClientProperty
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
