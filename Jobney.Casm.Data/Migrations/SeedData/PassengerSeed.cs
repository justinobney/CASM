using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Jobney.Casm.Domain;

namespace Jobney.Casm.Data.Migrations.SeedData
{
    public class PassengerSeed
    {
        public void Seed(DataContext context)
        {
            var passengers = new List<Passenger>
            {
                new Passenger
                {
                    EmailAddress = "chelseaobney@gmail.com",
                    FirstName = "Chelsea",
                    LastName = "Obney",
                    PhoneNumber = "225-123-4567"
                }
            };

            context.Set<Passenger>().AddOrUpdate(x => x.EmailAddress, passengers.ToArray());
            context.SaveChanges();
        }
    }
}