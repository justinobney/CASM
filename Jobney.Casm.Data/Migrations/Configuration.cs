using System.Data.Entity.Migrations;
using Jobney.Casm.Data.Migrations.SeedData;

namespace Jobney.Casm.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
        }
    }
}
