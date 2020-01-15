using Jeans.IdentityServer4.Server.Core;
using Jeans.IdentityServer4.Server.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 身份资源属性
    /// </summary>
    public class IdentityResourceProperty : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public int IdentityResourceId { get; set; }
        public IdentityResource IdentityResource { get; set; }
    }
}
