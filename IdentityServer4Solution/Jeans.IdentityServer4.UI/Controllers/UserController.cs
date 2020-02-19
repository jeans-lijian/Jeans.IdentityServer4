using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jeans.IdentityServer4.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IIdentityRepository<UserEntity> _repository;
        public UserController(IIdentityRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> List()
        {
            var results = await _repository.TableNoTracking.OrderBy(by => by.UserName).ToListAsync();
            return View(results);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(UserEntity entity)
        {
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
        public IActionResult Edit(UserEntity entity)
        {
            _repository.Update(entity);

            return RedirectToAction("List");
        }


        public IActionResult Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity != null)
            {
                _repository.Delete(entity);
            }

            return RedirectToAction("List");
        }

    }
}