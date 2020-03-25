using AutoMapper;
using IdentityServer4.Models;

namespace Jeans.IdentityServer4.Server.Core.AutoMapper
{
    public class IdentityResourceMapperProfile : Profile
    {
        public IdentityResourceMapperProfile()
        {
            EntityToModel();
        }

        private void EntityToModel()
        {
            CreateMap<Entity.IdentityResource, IdentityResource>();
        }
    }
}