using System.Collections.Generic;
using Jobney.Casm.Domain.Entities;

namespace Jobney.Casm.Domain.Entities
{
    public class Pilot : PersonBase
    {
        public ICollection<Trip> Trips { get; set; }
    }
}
