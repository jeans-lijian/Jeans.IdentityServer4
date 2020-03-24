using AutoMapper;
using IdentityServer4.Models;

namespace Jeans.IdentityServer4.Server.Core.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            EntityToModel();
        }

        private void EntityToModel()
        {
            CreateMap<Entity.Client, Client>();
        }
    }
}