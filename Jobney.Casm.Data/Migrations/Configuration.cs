using Jobney.Casm.Domain.Entities;

namespace Jobney.Casm.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            context.Set<Settings>().AddOrUpdate(s => s.Key, new[]
            {
                new Settings { Key = "City", Value = "Baton Rouge" },
                new Settings { Key = "State", Value = "Louisiana" }
            });

            context.SaveChanges();

        }
    }
}
