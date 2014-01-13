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

            context.Set<Airplane>().AddOrUpdate(x=>x.CallSign, new Airplane
            {
                Name = "SkyBallr",
                CallSign = "B477R"
            });

            context.Set<TripStatus>().AddOrUpdate(x => x.Name, new []
            {
                new TripStatus { Name = "Pending" },
                new TripStatus { Name = "Confirmed" },
                new TripStatus { Name = "Canceled" }
            });

            context.SaveChanges();

        }
    }
}
