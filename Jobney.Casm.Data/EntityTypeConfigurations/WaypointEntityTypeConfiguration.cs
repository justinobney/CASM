using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain.Entities;

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

            Property(x => x.Order)
                .IsRequired();

            HasMany(m => m.Passengers);

            HasMany(m => m.SpecialRequests);

            Property(m => m.TripId)
                .IsRequired();
        }
    }
}