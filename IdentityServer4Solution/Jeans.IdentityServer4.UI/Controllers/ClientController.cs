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
    /// <summary>
    /// 客户端
    /// </summary>
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IRepository<Client> _repository;
        public ClientController(IRepository<Client> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> List()
        {
            var results = await _repository.TableNoTracking.OrderBy(by => by.ClientName).ThenBy(by => by.Enabled).ToListAsync();

            return View(results);
        }


        public IActionResult Add()
        {
            BindProtocolTypes();
            return View(new Client());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Client entity)
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
            BindProtocolTypes();

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client entity)
        {
            _repository.Update(entity);

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Show(int id)
        {
            var entity = await _repository.TableNoTracking.Include(x => x.ClientGrantTypes)
                .Include(x => x.ClientSecrets)
                .Include(x => x.ClientScopes).FirstOrDefaultAsync(w => w.Id == id);

            return View(entity);
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

        private void BindProtocolTypes()
        {
            var ddl = new List<SelectListItem>
            {
                new SelectListItem("OpenIdConnect","oidc"),
                new SelectListItem("WsFederation","wsfed"),
                new SelectListItem("Saml2p","saml2p")
            };

            ViewBag.ProtocolTypeSelectList = ddl;
        }
    }
}