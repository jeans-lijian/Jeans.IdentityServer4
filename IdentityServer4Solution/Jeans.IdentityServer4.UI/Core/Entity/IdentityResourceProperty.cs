using Jeans.IdentityServer4.UI.Core;
using Jeans.IdentityServer4.UI.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Core.Entity
{
    /// <summary>
    /// 身份资源属性
    /// </summary>
    public class IdentityResourceProperty : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Guid IdentityResourceId { get; set; }
        public IdentityResource IdentityResource { get; set; }
    }
}