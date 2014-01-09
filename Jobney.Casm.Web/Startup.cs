using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using DotNetDoodle.Owin;
using DotNetDoodle.Owin.Dependencies;
using DotNetDoodle.Owin.Dependencies.Autofac;
using Jobney.Casm.Data;
using Jobney.Core.Domain;
using Jobney.Core.Domain.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jobney.Casm.Web.Startup))]
namespace Jobney.Casm.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            AutofacConfiguration.RegisterModules(builder);
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterOwinApplicationContainer();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseAutofacContainer(container);
        }
    }
}
