using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Jobney.Casm.Data.EntityTypeConfigurations;
using tcdev.Core.Data;
using tcdev.Core.Domain;

namespace Jobney.Casm.Data
{
    public class DataContext : DbContext, IDbContext
    {
        public DataContext(): base("DefaultConnection")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations
                .Add(new AirplaneEntityTypeConfiguration())
                .Add(new PassengerEntityTypeConfiguration())
                .Add(new PilotEntityTypeConfiguration())
                .Add(new SettingsEntityTypeConfiguration())
                .Add(new TripEntityTypeConfiguration())
                .Add(new TripStatusEntityTypeConfiguration())
                .Add(new WaypointEntityTypeConfiguration())
                .Add(new WaypointRequestEntityTypeConfiguration())
                .Add(new WaypointRequestTypeEntityTypeConfiguration());
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>(); ;
        }

        public new DbEntityEntry Entry<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            return base.Entry(entity);
        }
    }
}