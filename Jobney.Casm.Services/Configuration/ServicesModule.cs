using Autofac;

namespace Jobney.Casm.Services.Configuration
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsSelf();
        }
    }
}