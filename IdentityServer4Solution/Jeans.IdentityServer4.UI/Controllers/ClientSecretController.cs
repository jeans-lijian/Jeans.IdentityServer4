using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Client = Jeans.IdentityServer4.UI.Core.Entity.Client;

namespace Jeans.IdentityServer4.UI.Controllers
{
    public class ClientSecretController : BaseController
    {
        private readonly IRepository<ClientSecret> _repository;
        public ClientSecretController(IRepository<ClientSecret> repository, IRepository<Client> clientRepository) : base(clientRepository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> List()
        {
            var results = await _repository.TableNoTracking.Include(x => x.Client).OrderBy(by => by.Client.ClientName).ToListAsync();
            return View(results);
        }

        public IActionResult Add()
        {
            BindClientList();
            return View(new ClientSecret());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ClientSecret entity)
        {
            entity.Value = entity.Value.Sha256();
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

            BindClientList();

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClientSecret entity)
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