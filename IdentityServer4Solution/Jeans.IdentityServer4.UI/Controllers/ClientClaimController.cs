using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Controllers
{
    public class ClientClaimController : BaseController
    {
        private readonly IRepository<ClientClaim> _repository;
        public ClientClaimController(IRepository<ClientClaim> repository, IRepository<Client> clientRepository) : base(clientRepository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> List()
        {
            var results =await  _repository.TableNoTracking.Include(x=>x.Client).OrderBy(by => by.Client.ClientName).ToListAsync();
            return View(results);
        }

        public IActionResult Add()
        {
            BindClientList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ClientClaim entity)
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

            BindClientList();

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClientClaim entity)
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