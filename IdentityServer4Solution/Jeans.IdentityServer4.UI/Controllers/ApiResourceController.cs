using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Jeans.IdentityServer4.UI.Controllers
{
    public class ApiResourceController : Controller
    {
        public IActionResult List()
        {
            return View(new List<ApiResourceListVm>()
            {
                new ApiResourceListVm
                {
                    Name="测试",
                    Enabled=true
                }
            });
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction("List");
        }
    }
}