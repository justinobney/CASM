using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Jobney.Casm.Data.EntityTypeConfigurations;

namespace Jobney.Casm.Data
{
    public class DataContext : DbContext
    {
        public DataContext(): base("DefaultConnection")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations
                        .Add(new PilotEntityTypeConfiguration());
        }
    }
}