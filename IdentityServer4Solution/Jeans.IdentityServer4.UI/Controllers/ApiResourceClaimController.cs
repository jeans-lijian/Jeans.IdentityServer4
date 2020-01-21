using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Jeans.IdentityServer4.UI.Controllers
{
    [Authorize]
    public class ApiResourceClaimController : Controller
    {
        private readonly IRepository<ApiResourceClaim> _apiResourceClaimRepository;
        public ApiResourceClaimController(IRepository<ApiResourceClaim> apiResourceClaimRepository)
        {
            _apiResourceClaimRepository = apiResourceClaimRepository;
        }

        public async Task<IActionResult> List(int apiResourceId)
        {
            var results = await _apiResourceClaimRepository.TableNoTracking.Where(w => w.ApiResourceId == apiResourceId).ToListAsync();

            ViewBag.ApiResourceId = apiResourceId;

            return View(results);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ApiResourceClaim entity)
        {
            _apiResourceClaimRepository.Insert(entity);
            return RedirectToAction("List", new { entity.ApiResourceId });
        }

        public IActionResult Delete(int id, int apiResourceId)
        {
            var entity = _apiResourceClaimRepository.GetById(id);
            if (entity != null)
            {
                _apiResourceClaimRepository.Delete(entity);
            }

            return RedirectToAction("List", new { apiResourceId });
        }
    }
}