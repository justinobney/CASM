using Jobney.Core.Domain;

namespace Jobney.Casm.Domain
{
    public class PersonBase : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}