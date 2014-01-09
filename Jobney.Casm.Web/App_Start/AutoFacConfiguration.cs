using System.Reflection;
using System.Security.Principal;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using Jobney.Casm.Data.Configuration;
using Jobney.Casm.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Module = Autofac.Module;

namespace Jobney.Casm.Web
{
    public class AutofacConfiguration
    {
        public static void Configure()
        {
            
        }

        public static void RegisterModules(ContainerBuilder builder)
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

            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
                .As<UserManager<ApplicationUser>>()
                .InstancePerLifetimeScope();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            
            builder.RegisterType(typeof(UserValidator<>));

        }
    }
}