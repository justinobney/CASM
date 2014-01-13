using System.Collections.Generic;

namespace Jobney.Casm.Domain.Entities
{
    public class Passenger : PersonBase
    {
        public ICollection<Trip> Trips { get; set; } 
    }
}