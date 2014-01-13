using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain.Entities;

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

            Property(m => m.StatusId)
                .IsRequired();

            Property(x => x.AirplaneId)
                .IsRequired();

            HasMany(m => m.Passengers);

            HasMany(m => m.Pilots);

            HasMany(m => m.Waypoints);
        }
    }
}