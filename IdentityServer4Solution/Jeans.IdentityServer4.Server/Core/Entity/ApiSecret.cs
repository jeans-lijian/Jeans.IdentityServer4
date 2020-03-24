using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// Api秘钥
    /// </summary>
    public class ApiSecret : BaseEntity
    {
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; } = "SharedSecret";
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public Guid ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}