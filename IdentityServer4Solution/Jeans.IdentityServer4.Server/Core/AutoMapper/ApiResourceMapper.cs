using AutoMapper;
using IdentityServer4.Models;

namespace Jeans.IdentityServer4.Server.Core.AutoMapper
{
    public static class ApiResourceMapper
    {
        private static IMapper Mapper { get; }

        static ApiResourceMapper()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceMapperProfile>()).CreateMapper();
        }

        public static ApiResource ToModel(this Entity.ApiResource entity)
        {
            return entity == null ? null : Mapper.Map<ApiResource>(entity);
        }
    }
}