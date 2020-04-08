using System;

namespace LJ.Ids4.Core.Domain.Clients
{
    /// <summary>
    /// 客户跨域
    /// </summary>
    public class ClientCorsOrigin : BaseEntity
    {
        public string Origin { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}