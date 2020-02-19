using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Controllers
{
    public class IdentityResourceController : Controller
    {
        private readonly IRepository<IdentityResource> _repository;
        public IdentityResourceController(IRepository<IdentityResource> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> List()
        {
            var results = await _repository.TableNoTracking.OrderByDescending(by => by.Enabled)
                                        .OrderBy(by => by.Created).ToListAsync();

            return View(results);
        }

        public IActionResult Add()
        {
            return View(new IdentityResource());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(IdentityResource entity)
        {
            entity.Created = DateTime.Now;
            _repository.Insert(entity);

            return RedirectToAction("List");
        }


        public IActionResult Edit(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IdentityResource entity)
        {
            entity.Updated = DateTime.Now;
            _repository.Update(entity);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var entity = _repository.GetById(id);
            _repository.Delete(entity);

            return RedirectToAction("List");
        }
    }
}