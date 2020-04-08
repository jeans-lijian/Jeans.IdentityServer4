using System;

namespace LJ.Ids4.Core.Domain.Clients
{
    /// <summary>
    /// 客户属性
    /// </summary>
    public class ClientProperty : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}