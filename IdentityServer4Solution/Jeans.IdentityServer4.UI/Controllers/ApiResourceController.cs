using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Controllers
{
    [Authorize]
    public class ApiResourceController : Controller
    {
        private readonly IRepository<ApiResource> _apiResourceRepository;
        public ApiResourceController(IRepository<ApiResource> apiResourceRepository)
        {
            _apiResourceRepository = apiResourceRepository;
        }

        public async Task<IActionResult> List()
        {
            var results = await _apiResourceRepository.TableNoTracking.OrderByDescending(by => by.Enabled).ToListAsync();

            return View(results);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ApiResource entity)
        {
            _apiResourceRepository.Insert(entity);

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _apiResourceRepository.TableNoTracking.FirstOrDefaultAsync(w => w.Id == id);

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApiResource model)
        {
            var entity = _apiResourceRepository.GetById(model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.DisplayName = model.DisplayName;
                entity.Description = model.Description;
                entity.Enabled = model.Enabled;
                entity.NonEditable = model.NonEditable;
                entity.Updated = DateTime.Now;
                entity.LastAccessed = DateTime.Now;

                _apiResourceRepository.Update(entity);

                return RedirectToAction("List");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var entity = _apiResourceRepository.GetById(id);
            if (entity != null)
            {
                _apiResourceRepository.Delete(entity);
            }

            return RedirectToAction("List");
        }
    }
}