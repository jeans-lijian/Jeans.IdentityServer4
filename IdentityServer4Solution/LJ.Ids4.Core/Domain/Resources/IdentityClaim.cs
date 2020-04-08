using System;

namespace LJ.Ids4.Core.Domain.Resources
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