using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Jeans.IdentityServer4.UI.Controllers
{
    public class ClientGrantTypeController : BaseController
    {
        private readonly IRepository<ClientGrantType> _repository;
        public ClientGrantTypeController(IRepository<ClientGrantType> repository, IRepository<Client> clientRepository) : base(clientRepository)
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
            BindGrantTypeList();
            BindClientList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ClientGrantType entity)
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

            BindGrantTypeList();
            BindClientList();

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClientGrantType entity)
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

        private void BindGrantTypeList()
        {
            var dd = new List<SelectListItem>
            {
                new SelectListItem("Implicit" , "implicit"),
                new SelectListItem("Hybrid" , "hybrid"),
                new SelectListItem("AuthorizationCode" , "authorization_code"),
                new SelectListItem("ClientCredentials" , "client_credentials"),
                new SelectListItem("ResourceOwnerPassword" , "password"),
                new SelectListItem("DeviceFlow" , "urn:ietf:params:oauth:grant-type:device_code")
            };

            ViewBag.GrantTypeSelectItemList = dd;
        }

    }
}