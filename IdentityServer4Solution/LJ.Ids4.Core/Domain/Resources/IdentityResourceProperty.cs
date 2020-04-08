using System;

namespace LJ.Ids4.Core.Domain.Resources
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