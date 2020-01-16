using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Jeans.IdentityServer4.UI.Controllers
{
    /// <summary>
    /// 客户端
    /// </summary>
    public class ClientController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}