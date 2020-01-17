using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Core.Entity
{
    /// <summary>
    /// Api资源属性
    /// </summary>
    public class ApiResourceProperty : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}
