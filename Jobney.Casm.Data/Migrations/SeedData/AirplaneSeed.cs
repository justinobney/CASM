using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Jobney.Casm.Domain;

namespace Jobney.Casm.Data.Migrations.SeedData
{
    public class AirplaneSeed
    {
        public void Seed(DataContext context)
        {
            var theplanes = new List<Airplane>
            {
                new Airplane{Name = "SkyThunder", CallSign = "1337"}
            };

            context.Set<Airplane>().AddOrUpdate(x => x.CallSign, theplanes.ToArray());
            context.SaveChanges();
        }
    }
}