using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain;

namespace Jobney.Casm.Data.EntityTypeConfigurations
{
    public class TripEntityTypeConfiguration : EntityTypeConfiguration<Trip>
    {
        public TripEntityTypeConfiguration()
        {
            Property(x => x.Id)
                .IsRequired();

            Property(x => x.Name)
                .IsRequired();

            Property(x => x.AirplaneId)
                .IsRequired();

            Property(x => x.ScheduledBy)
                .IsRequired();
        }
    }
}