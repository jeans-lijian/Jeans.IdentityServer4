using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Jeans.IdentityServer4.UI.Data;

namespace Jeans.IdentityServer4.UI.Core.AutofacConfig
{
    public class AutofacConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityServerDbContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<ObjectDbContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}
