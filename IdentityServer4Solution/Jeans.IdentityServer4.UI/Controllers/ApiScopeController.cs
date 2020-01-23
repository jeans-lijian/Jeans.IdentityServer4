using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Jeans.IdentityServer4.UI.Data;
using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jeans.IdentityServer4.UI.Controllers
{
    [Authorize]
    public class ApiScopeController : Controller
    {
        private readonly IRepository<ApiScope> _apiScopeRepository;
        private readonly IRepository<ApiResource> _apiResourceRepository;
        public ApiScopeController(
            IRepository<ApiScope> apiScopeRepository,
            IRepository<ApiResource> apiResourceRepository)
        {
            _apiScopeRepository = apiScopeRepository;
            _apiResourceRepository = apiResourceRepository;
        }


        public async Task<IActionResult> List()
        {
            var results = new List<ApiScope> {
                new ApiScope()
            }; //await _apiScopeRepository.TableNoTracking.Include(x => x.ApiResource).ToListAsync();

            return View(results);
        }


        public IActionResult Add()
        {
            //BindApiResourceList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ApiScope entity)
        {
            //_apiScopeRepository.Insert(entity);

            return RedirectToAction("List");
        }


        public IActionResult Edit(int id)
        {
            //var entity = _apiScopeRepository.GetById(id);
            //if (entity==null)
            //{
            //    return RedirectToAction("List");
            //}

            //BindApiResourceList();

            //return View(entity);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApiScope entity)
        {
            _apiScopeRepository.Update(entity);
            return RedirectToAction("List");
        }


        public IActionResult Delete(int id)
        {
            var entity = _apiScopeRepository.GetById(id);
            if (entity != null)
            {
                _apiScopeRepository.Delete(entity);
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