using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 身份声明
    /// </summary>
    public class IdentityClaim : BaseEntity
    {
        public string Type { get; set; }

        public int IdentityResourceId { get; set; }
        public IdentityResource IdentityResource { get; set; }
    }
}
