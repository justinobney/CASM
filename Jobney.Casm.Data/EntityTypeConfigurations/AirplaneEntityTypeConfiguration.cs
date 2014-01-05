using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain;

namespace Jobney.Casm.Data.EntityTypeConfigurations
{
    public class AirplaneEntityTypeConfiguration : EntityTypeConfiguration<Airplane>
    {
        public AirplaneEntityTypeConfiguration()
        {
            Property(x => x.Id)
                .IsRequired();

            Property(x => x.Name)
                .IsRequired();

            Property(x => x.CallSign)
                .IsRequired();
        }
    }
}