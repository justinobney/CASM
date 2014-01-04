using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain;

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
        }
    }
}