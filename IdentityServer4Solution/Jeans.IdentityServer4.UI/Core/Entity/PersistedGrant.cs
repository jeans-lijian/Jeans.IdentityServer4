using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Core.Entity
{
    public class PersistedGrant
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public string SubjectId { get; set; }
        public string ClientId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? Expiration { get; set; }
        public string Data { get; set; }
    }
}
