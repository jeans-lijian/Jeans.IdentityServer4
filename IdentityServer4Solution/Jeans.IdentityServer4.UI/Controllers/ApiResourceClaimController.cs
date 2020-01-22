using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Jeans.IdentityServer4.UI.Controllers
{
    [Authorize]
    public class ApiResourceClaimController : Controller
    {
        private readonly IRepository<ApiResourceClaim> _apiResourceClaimRepository;
        private readonly IRepository<ApiResource> _apiResourceRepository;
        public ApiResourceClaimController(
            IRepository<ApiResourceClaim> apiResourceClaimRepository,
            IRepository<ApiResource> apiResourceRepository)
        {
            _apiResourceClaimRepository = apiResourceClaimRepository;
            _apiResourceRepository = apiResourceRepository;
        }


        public async Task<IActionResult> List()
        {
            var results = await _apiResourceClaimRepository.TableNoTracking
                                            .Include(x=>x.ApiResource)
                                            .OrderBy(by => by.ApiResource.Name).ToListAsync();

            return View(results);
        }


        public IActionResult Add()
        {
            BindApiResourceList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ApiResourceClaim entity)
        {
            _apiResourceClaimRepository.Insert(entity);
            return RedirectToAction("List");
        }


        public IActionResult Edit(int id)
        {
            var entity = _apiResourceClaimRepository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }

            BindApiResourceList();

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApiResourceClaim model)
        {
            _apiResourceClaimRepository.Update(model);

            return RedirectToAction("List");
        }


        public IActionResult Delete(int id)
        {
            var entity = _apiResourceClaimRepository.GetById(id);
            if (entity != null)
            {
                _apiResourceClaimRepository.Delete(entity);
            }

            return RedirectToAction("List");
        }


        private void BindApiResourceList()
        {
            var dd = _apiResourceRepository.TableNoTracking.OrderBy(by => by.Name).Select(s => new SelectListItem(s.Name, s.Id.ToString())).ToList();
            ViewBag.ApiResourceSelectItemList = dd;
        }
    }
}