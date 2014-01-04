using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Jobney.Casm.Domain;

namespace Jobney.Casm.Data.Migrations.SeedData
{
    public class PilotSeed
    {
        public void Seed(DataContext context)
        {
            var pilots = new List<Pilot>
            {
                new Pilot
                {
                    EmailAddress = "justin@envoc.com",
                    FirstName = "Justin",
                    LastName = "Obney",
                    PhoneNumber = "225-123-4567"
                }
            };

            context.Set<Pilot>().AddOrUpdate(x => x.EmailAddress, pilots.ToArray());
            context.SaveChanges();
        }
    }
}