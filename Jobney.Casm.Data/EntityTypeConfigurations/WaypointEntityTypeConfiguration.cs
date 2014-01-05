using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain;

namespace Jobney.Casm.Data.EntityTypeConfigurations
{
    public class WaypointEntityTypeConfiguration : EntityTypeConfiguration<Waypoint>
    {
        public WaypointEntityTypeConfiguration()
        {
            Property(x => x.Id)
                .IsRequired();

            Property(x => x.City)
                .IsRequired();

            Property(x => x.State)
                .IsRequired();
        }
    }
}