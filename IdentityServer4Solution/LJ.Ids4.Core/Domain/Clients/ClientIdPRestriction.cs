using System;

namespace LJ.Ids4.Core.Domain.Clients
{
    /// <summary>
    /// 客户端限制
    /// </summary>
    public class ClientIdPRestriction : BaseEntity
    {
        public string Provider { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}