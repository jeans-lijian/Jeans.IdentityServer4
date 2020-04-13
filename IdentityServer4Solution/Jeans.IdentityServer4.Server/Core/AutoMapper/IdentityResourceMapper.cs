using AutoMapper;
using IdentityServer4.Models;

namespace Jeans.IdentityServer4.Server.Core.AutoMapper
{
    public static class IdentityResourceMapper
    {
        private static IMapper Mapper { get; }

        static IdentityResourceMapper()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceMapperProfile>()).CreateMapper();
        }

        public static IdentityResource ToModel(this LJ.Ids4.Core.Domain.Resources.IdentityResource entity)
        {
            return entity == null ? null : Mapper.Map<IdentityResource>(entity);
        }
    }
}