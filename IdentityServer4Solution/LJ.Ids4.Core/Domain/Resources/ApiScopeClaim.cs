namespace LJ.Ids4.Core.Domain.Resources
{
    /// <summary>
    /// Api作用域，声明
    /// </summary>
    public class ApiScopeClaim : BaseEntity
    {
        public string Type { get; set; }

        public int ApiScopeId { get; set; }
        public ApiScope ApiScope { get; set; }
    }
}