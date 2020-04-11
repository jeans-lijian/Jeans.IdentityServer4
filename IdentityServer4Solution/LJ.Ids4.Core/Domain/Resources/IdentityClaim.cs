namespace LJ.Ids4.Core.Domain.Resources
{
    /// <summary>
    /// 身份声明
    /// </summary>
    public class IdentityClaim : BaseEntity
    {
        public string Type { get; set; }

        public int IdentityResourceId { get; set; }
        public IdentityResource IdentityResource { get; set; }
    }
}