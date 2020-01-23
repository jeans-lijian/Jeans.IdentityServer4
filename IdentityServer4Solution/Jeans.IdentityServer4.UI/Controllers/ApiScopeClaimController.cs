using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Mvc;

namespace Jeans.IdentityServer4.UI.Controllers
{
    public class ApiScopeClaimController : Controller
    {
        private readonly IRepository<ApiScope> _apiScopeRepository;
        private readonly IRepository<ApiScopeClaim> _apiScopeClaimRepository;
        public ApiScopeClaimController(
            IRepository<ApiScope> apiScopeRepository,
            IRepository<ApiScopeClaim> apiScopeClaimRepository)
        {
            _apiScopeRepository = apiScopeRepository;
            _apiScopeClaimRepository = apiScopeClaimRepository;
        }

        public IActionResult List()
        {
            var results = new List<ApiScopeClaim>();
            return View(results);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ApiScopeClaim entity)
        {
            return RedirectToAction("List");
        }


        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApiScopeClaim entity)
        {
            return RedirectToAction("List");
        }


        public IActionResult Delete(int id)
        {
            var entity = _apiScopeClaimRepository.GetById(id);
            if (entity != null)
            {
                _apiScopeClaimRepository.Delete(entity);
            }

            return RedirectToAction("List");
        }

    }
}