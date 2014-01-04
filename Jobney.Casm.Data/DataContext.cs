using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Jobney.Casm.Data.EntityTypeConfigurations;

namespace Jobney.Casm.Data
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}