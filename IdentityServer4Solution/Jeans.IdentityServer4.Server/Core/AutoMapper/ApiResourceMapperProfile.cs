using AutoMapper;
using IdentityServer4.Models;

namespace Jeans.IdentityServer4.Server.Core.AutoMapper
{
    public class ApiResourceMapperProfile : Profile
    {
        public ApiResourceMapperProfile()
        {
            EntityToModel();
        }

        private void EntityToModel()
        {
            CreateMap<Entity.ApiResource, ApiResource>();
        }
    }
}