using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jobney.Casm.Web.Startup))]
namespace Jobney.Casm.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
