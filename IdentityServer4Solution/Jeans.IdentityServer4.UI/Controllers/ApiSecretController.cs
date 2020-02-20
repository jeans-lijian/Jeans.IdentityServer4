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
    public class ApiSecretController : Controller
    {
        private readonly IRepository<ApiSecret> _apiSecretRepository;
        private readonly IRepository<ApiResource> _apiResourceRepository;
        public ApiSecretController(
            IRepository<ApiSecret> apiSecretRepository,
            IRepository<ApiResource> apiResourceRepository)
        {
            _apiSecretRepository = apiSecretRepository;
            _apiResourceRepository = apiResourceRepository;
        }

        public async Task<IActionResult> List()
        {
            var results = await _apiSecretRepository.TableNoTracking.Include(x => x.ApiResource)
                                    .OrderBy(by => by.ApiResource.Name).ToListAsync();

            return View(results);
        }

        public IActionResult Add()
        {
            BindApiResourceList();

            return View(new ApiSecret());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ApiSecret entity)
        {
            _apiSecretRepository.Insert(entity);

            return RedirectToAction("List");
        }


        public IActionResult Edit(int id)
        {
            var entity = _apiSecretRepository.GetById(id);
            if (entity == null)
            {
                return RedirectToAction("List");
            }

            BindApiResourceList();

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApiSecret entity)
        {
            _apiSecretRepository.Update(entity);

            return RedirectToAction("List");
        }


        public IActionResult Delete(int id)
        {
            var entity = _apiSecretRepository.GetById(id);
            if (entity != null)
            {
                _apiSecretRepository.Delete(entity);
            }

            return RedirectToAction("List");
        }

        private void BindApiResourceList()
        {
            var dd = _apiResourceRepository.TableNoTracking.Where(w => w.Enabled)
                            .OrderBy(by => by.Name).Select(s => new SelectListItem(s.Name, s.Id.ToString())).ToList();

            ViewBag.ApiResourceSelectItemList = dd;
        }
    }
}