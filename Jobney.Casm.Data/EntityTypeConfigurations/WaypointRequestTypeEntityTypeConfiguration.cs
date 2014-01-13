using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain.Entities;

namespace Jobney.Casm.Data.EntityTypeConfigurations
{
    public class WaypointRequestTypeEntityTypeConfiguration : EntityTypeConfiguration<WaypointRequestType>
    {
        public WaypointRequestTypeEntityTypeConfiguration() {
            Property(x => x.Id)
                .IsRequired();

            Property(x => x.Name)
                .IsRequired();
        }
    }
}