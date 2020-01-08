using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// Api作用域
    /// </summary>
    public class ApiScope
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; } = true;
        public List<ApiScopeClaim> ApiScopeClaims { get; set; }

        public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}
