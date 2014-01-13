using System.Data.Entity.ModelConfiguration;
using Jobney.Casm.Domain.Entities;

namespace Jobney.Casm.Data.EntityTypeConfigurations
{
    public class SettingsEntityTypeConfiguration : EntityTypeConfiguration<Settings>
    {
        public SettingsEntityTypeConfiguration()
        {
            Property(x => x.Id)
                .IsRequired();

            Property(x => x.Key)
                .IsRequired();

            Property(x => x.Value)
                .IsRequired();
        }
    }
}