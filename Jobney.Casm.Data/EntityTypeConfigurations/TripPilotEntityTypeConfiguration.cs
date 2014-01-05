using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain;

namespace Jobney.Casm.Data.EntityTypeConfigurations
{
    public class TripPilotEntityTypeConfiguration : EntityTypeConfiguration<TripPilot>
    {
        public TripPilotEntityTypeConfiguration()
        {
            Property(x => x.Id)
                .IsRequired();
        }
    }
}