using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Jobney.Casm.Data.EntityTypeConfigurations;
using Jobney.Core.Domain;
using Jobney.Core.Domain.Interfaces;

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
                .Add(new PilotEntityTypeConfiguration())
                .Add(new PassengerEntityTypeConfiguration());
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>(); ;
        }

        public new DbEntityEntry Entry<TEntity>(TEntity entity) where TEntity : Entity
        {
            return base.Entry(entity);
        }
    }
}