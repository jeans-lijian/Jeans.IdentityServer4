using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult List()
        {
            var results = new List<ApiSecret>();
            return View(results);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ApiSecret entity)
        {
            return RedirectToAction("List");
        }


        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApiSecret entity)
        {
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
    }
}