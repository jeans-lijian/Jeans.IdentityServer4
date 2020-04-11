namespace LJ.Ids4.Core.Domain.Resources
{
    /// <summary>
    /// Api资源属性
    /// </summary>
    public class ApiResourceProperty : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}