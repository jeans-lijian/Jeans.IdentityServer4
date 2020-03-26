using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// Api作用域，声明
    /// </summary>
    public class ApiScopeClaim : BaseEntity
    {
        public string Type { get; set; }

        public Guid ApiScopeId { get; set; }
        public ApiScope ApiScope { get; set; }
    }
}