using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> List()
        {
            var results = await _apiScopeClaimRepository.TableNoTracking.Include(x => x.ApiScope).OrderBy(by => by.ApiScope.Name).ToListAsync();
            return View(results);
        }

        public IActionResult Add()
        {
            BindApiScopeList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ApiScopeClaim entity)
        {
            _apiScopeClaimRepository.Insert(entity);

            return RedirectToAction("List");
        }


        public IActionResult Edit(int id)
        {
            var entity = _apiScopeClaimRepository.GetById(id);
            if (entity == null)
            {
                return RedirectToAction("List");
            }

            BindApiScopeList();

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApiScopeClaim entity)
        {
            _apiScopeClaimRepository.Update(entity);

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

        private void BindApiScopeList()
        {
            var dd = _apiScopeRepository.TableNoTracking
                            .OrderBy(by => by.Name)
                            .Select(s => new SelectListItem(s.Name, s.Id.ToString())).ToList();
            ViewBag.ApiScopeSelectItemList = dd;
        }
    }
}