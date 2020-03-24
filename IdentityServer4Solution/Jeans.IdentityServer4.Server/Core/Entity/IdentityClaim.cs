using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// 身份声明
    /// </summary>
    public class IdentityClaim : BaseEntity
    {
        public string Type { get; set; }

        public Guid IdentityResourceId { get; set; }
        public IdentityResource IdentityResource { get; set; }
    }
}