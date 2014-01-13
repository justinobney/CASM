using tcdev.Core.Domain;

namespace Jobney.Casm.Domain.Entities
{
    public class PersonBase : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}