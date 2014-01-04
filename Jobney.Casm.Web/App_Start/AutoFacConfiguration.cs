using System.Reflection;
using System.Security.Principal;
using System.Web;
using Autofac;
using Autofac.Core;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Jobney.Casm.Data.Configuration;
using Microsoft.AspNet.Identity;
using Module = Autofac.Module;

namespace Jobney.Casm.Web
{
    public class AutofacConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            RegisterModules(builder);
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<DataModule>();
            builder.RegisterModule<WebModule>();
        }
    }
}

namespace Jobney.Casm.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => HttpContext.Current.User.Identity)
                .As<IIdentity>()
                .InstancePerLifetimeScope();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            
            builder.RegisterType(typeof(UserValidator<>));

        }
    }
}