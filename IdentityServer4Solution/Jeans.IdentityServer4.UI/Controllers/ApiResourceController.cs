using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Jeans.IdentityServer4.UI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction("List");
        }
    }
}