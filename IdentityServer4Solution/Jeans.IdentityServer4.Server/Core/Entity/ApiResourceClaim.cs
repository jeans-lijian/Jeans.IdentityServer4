using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// Api资源声明
    /// </summary>
    public class ApiResourceClaim : BaseEntity
    {
        public string Type { get; set; }

        public Guid ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}