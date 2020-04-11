namespace LJ.Ids4.Core.Domain.Resources
{
    /// <summary>
    /// Api资源声明
    /// </summary>
    public class ApiResourceClaim : BaseEntity
    {
        public string Type { get; set; }

        public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}