using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain.Entities;

namespace Jobney.Casm.Data.EntityTypeConfigurations
{
    public class WaypointRequestEntityTypeConfiguration : EntityTypeConfiguration<WaypointRequest>
    {
        public WaypointRequestEntityTypeConfiguration()
        {
            Property(x => x.Id)
                .IsRequired();

            Property(x => x.Description)
                .IsRequired();

            Property(x => x.TypeId)
                .IsRequired();

            Property(x => x.WaypointId)
                .IsRequired();
        }
    }
}