using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Jeans.IdentityServer4.UI.Data;
using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Jeans.IdentityServer4.UI.Controllers
{
    [Authorize]
    public class ApiScopeController : Controller
    {
        private readonly IRepository<ApiScope> _apiScopeRepository;
        public ApiScopeController(IRepository<ApiScope> apiScopeRepository)
        {
            _apiScopeRepository = apiScopeRepository;
        }

        public async Task<IActionResult> List(int apiResourceId)
        {
            var results = await _apiScopeRepository.TableNoTracking.Where(w => w.ApiResourceId == apiResourceId).ToListAsync();

            ViewBag.ApiResourceId = apiResourceId;

            return View(results);
        }

        public IActionResult Delete(int id, int apiResourceId)
        {
            var entity = _apiScopeRepository.GetById(id);
            if (entity != null)
            {
                _apiScopeRepository.Delete(entity);
            }

            return RedirectToAction("List", new { apiResourceId });
        }

    }
}