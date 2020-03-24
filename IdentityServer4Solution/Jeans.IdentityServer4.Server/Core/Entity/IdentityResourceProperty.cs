using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
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