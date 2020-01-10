using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 身份资源
    /// </summary>
    public class IdentityResource : BaseEntity
    {
        public bool Enabled { get; set; } = true;
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public bool NonEditable { get; set; }

        public List<IdentityResourceProperty> IdentityResourceProperties { get; set; }
        public List<IdentityClaim> IdentityClaims { get; set; }
    }
}
