namespace LJ.Ids4.Core.Domain.Clients
{
    /// <summary>
    /// 客户授权类型
    /// </summary>
    public class ClientGrantType : BaseEntity
    {
        public string GrantType { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}