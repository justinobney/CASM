using Autofac;
using Jobney.Casm.Data.Configuration;
using Jobney.Casm.Services.Configuration;

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
            builder.RegisterModule<ServicesModule>();
        }
    }
}