using System;

namespace Jeans.IdentityServer4.Server.Core.Entity
{
    /// <summary>
    /// Api资源属性
    /// </summary>
    public class ApiResourceProperty : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Guid ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}