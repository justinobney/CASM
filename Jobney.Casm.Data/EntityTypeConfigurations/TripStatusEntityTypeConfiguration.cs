using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain.Entities;

namespace Jobney.Casm.Data.EntityTypeConfigurations
{
    public class TripStatusEntityTypeConfiguration : EntityTypeConfiguration<TripStatus>
    {
        public TripStatusEntityTypeConfiguration() {
            Property(x => x.Id)
                .IsRequired();

            Property(m => m.Name)
                .IsRequired();
        }
    }
}