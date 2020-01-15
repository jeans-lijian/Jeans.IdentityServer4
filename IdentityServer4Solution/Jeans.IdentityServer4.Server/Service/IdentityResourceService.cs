using Jeans.IdentityServer4.Server.Core.Entity;
using Jeans.IdentityServer4.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.Server.Service
{
    public class IdentityResourceService : IIdentityResourceService
    {
        private readonly IRepository<IdentityResource> _identityResourceRepository;
        public IdentityResourceService(IRepository<IdentityResource> identityResourceRepository)
        {
            _identityResourceRepository = identityResourceRepository;
        }


    }
}
