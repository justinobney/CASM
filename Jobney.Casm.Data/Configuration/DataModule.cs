using Autofac;
using Jobney.Core;
using Jobney.Core.Domain.Interfaces;

namespace Jobney.Casm.Data.Configuration
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>()
                .As<IDbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>));
        }
    }
}
