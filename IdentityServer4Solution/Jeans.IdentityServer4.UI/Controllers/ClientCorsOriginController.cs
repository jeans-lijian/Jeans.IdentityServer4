using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jeans.IdentityServer4.UI.Controllers
{
    [Authorize]
    public class ClientCorsOriginController : Controller
    {
        private readonly IRepository<ClientCorsOrigin> _repository;
        public ClientCorsOriginController(IRepository<ClientCorsOrigin> repository)
        {
            _repository = repository;
        }

        public IActionResult List()
        {
            //var results = _repository.TableNoTracking.OrderBy(by => by.Client.ClientName).ToListAsync();
            return View(new List<ClientCorsOrigin>());
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return RedirectToAction("List");
        }

    }
}