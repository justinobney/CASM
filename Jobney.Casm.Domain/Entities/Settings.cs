using tcdev.Core.Domain;

namespace Jobney.Casm.Domain.Entities
{
    public class Settings : EntityBase
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}