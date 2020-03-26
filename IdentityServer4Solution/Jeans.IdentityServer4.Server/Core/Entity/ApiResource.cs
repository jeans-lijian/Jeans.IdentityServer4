using System;
using System.Collections.Generic;

namespace Jeans.IdentityServer4.Server.Core.Entity {
    /// <summary>
    /// Api资源
    /// </summary>
    public class ApiResource : BaseEntity {
        public bool Enabled { get; set; } = true;
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string AllowedAccessTokenSigningAlgorithms { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public bool NonEditable { get; set; }

        public List<ApiResourceProperty> ApiResourceProperties { get; set; }
        public List<ApiResourceClaim> ApiResourceClaims { get; set; }
        public List<ApiScope> ApiScopes { get; set; }

        public List<ApiSecret> ApiSecrets { get; set; }
    }
}