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
    public class ClientScopeController : Controller
    {
        private readonly IRepository<ClientScope> _repository;
        public ClientScopeController(IRepository<ClientScope> repository)
        {
            _repository = repository;
        }

        public IActionResult List()
        {
            //var results = _repository.TableNoTracking.OrderBy(by => by.Client.ClientName).ToListAsync();
            return View(new List<ClientScope>());
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