namespace LJ.Ids4.Core.Domain.Clients
{
    /// <summary>
    /// 客户重定向Uri
    /// </summary>
    public class ClientRedirectUri : BaseEntity
    {
        public string RedirectUri { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}