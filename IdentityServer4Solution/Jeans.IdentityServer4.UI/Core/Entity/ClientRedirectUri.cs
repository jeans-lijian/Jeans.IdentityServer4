using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Core.Entity
{
    /// <summary>
    /// 客户重定向Uri
    /// </summary>
    public class ClientRedirectUri : BaseEntity
    {
        public string RedirectUri { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}