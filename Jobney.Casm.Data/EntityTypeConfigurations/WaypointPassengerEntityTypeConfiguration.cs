using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain;

namespace Jobney.Casm.Data.EntityTypeConfigurations
{
    public class WaypointPassengerEntityTypeConfiguration : EntityTypeConfiguration<WaypointPassenger>
    {
        public WaypointPassengerEntityTypeConfiguration()
        {
            Property(x => x.Id)
                .IsRequired();
        }
    }
}