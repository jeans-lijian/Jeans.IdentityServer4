using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private readonly IRepository<Client> _clientRepository;
        public BaseController(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [NonAction]
        public void BindClientList()
        {
            var dd = _clientRepository.TableNoTracking.Where(w => w.Enabled)
                            .OrderBy(by => by.ClientName).Select(s => new SelectListItem(s.ClientName, s.Id.ToString())).ToList();

            ViewBag.ClientSelectItemList = dd;
        }
    }
}
