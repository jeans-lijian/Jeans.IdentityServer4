using System.ComponentModel.DataAnnotations;

namespace Jeans.IdentityServer4.UI.ViewModel
{
    public class ApiResourceListVm : ApiResourceVm
    {
        public int Id { get; set; }

        [Display(Name = "创建时间")]
        public string CreateTimeStr { get; set; }

        [Display(Name = "更新时间")]
        public string UpdateTimeStr { get; set; }
    }
}
