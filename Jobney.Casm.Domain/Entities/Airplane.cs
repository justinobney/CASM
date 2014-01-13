using System.Collections.Generic;
using tcdev.Core.Domain;

namespace Jobney.Casm.Domain.Entities
{
    public class Airplane : EntityBase
    {
        public string Name { get; set; }
        public string CallSign { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }

        public ICollection<Pilot> DefaultPilotList { get; set; }
        public ICollection<Trip> Trips { get; set; } 
    }
}