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
    public class ClientPropertyController : Controller
    {
        private readonly IRepository<ClientProperty> _repository;
        public ClientPropertyController(IRepository<ClientProperty> repository)
        {
            _repository = repository;
        }

        public IActionResult List()
        {
            //var results = _repository.TableNoTracking.OrderBy(by => by.Client.ClientName).ToListAsync();
            return View(new List<ClientProperty>());
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