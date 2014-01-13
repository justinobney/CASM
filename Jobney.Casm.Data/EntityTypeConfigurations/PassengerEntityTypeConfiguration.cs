using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain.Entities;

namespace Jobney.Casm.Data.EntityTypeConfigurations
{
    public class PassengerEntityTypeConfiguration : EntityTypeConfiguration<Passenger>
    {
        public PassengerEntityTypeConfiguration()
        {
            Property(x => x.Id)
                .IsRequired();

            Property(x => x.EmailAddress)
                .IsRequired();

            HasMany(m => m.Trips);
        }
    }
}