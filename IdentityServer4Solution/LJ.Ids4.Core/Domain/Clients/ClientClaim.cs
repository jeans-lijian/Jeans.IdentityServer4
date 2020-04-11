namespace LJ.Ids4.Core.Domain.Clients
{
    /// <summary>
    /// 客户声明
    /// </summary>
    public class ClientClaim : BaseEntity
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}