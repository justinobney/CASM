using Autofac;
using tcdev.Core.Data;

namespace Jobney.Casm.Data.Configuration
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>()
                .As<IDbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>));
        }
    }
}
