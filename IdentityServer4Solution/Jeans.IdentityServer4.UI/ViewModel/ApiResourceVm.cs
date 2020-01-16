using System.ComponentModel.DataAnnotations;

namespace Jeans.IdentityServer4.UI.ViewModel
{
    public class ApiResourceVm
    {
        [Display(Name = "是否启用")]
        public bool Enabled { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "显示名称")]
        public string DisplayName { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        [Display(Name = "签名算法")]
        public string AllowedAccessTokenSigningAlgorithms { get; set; }

        [Display(Name = "是否编辑")]
        public bool NonEditable { get; set; }
    }
}
