﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeans.IdentityServer4.UI.Core.Entity;
using Jeans.IdentityServer4.UI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jeans.IdentityServer4.UI.Controllers
{
    [Authorize]
    public class ClientClaimController : Controller
    {
        private readonly IRepository<ClientClaim> _repository;
        public ClientClaimController(IRepository<ClientClaim> repository)
        {
            _repository = repository;
        }

        public IActionResult List()
        {
            return View();
        }
    }
}