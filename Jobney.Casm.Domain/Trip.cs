using System.Collections.Generic;
using Jobney.Core.Domain;

namespace Jobney.Casm.Domain
{
    public class Trip : Entity
    {
        public string Name { get; set; }
        public int AirplaneId { get; set; }
        //public virtual Airplane Airplane { get; set; }
        public TripStatus Status { get; set; }
        public List<TripPilot> PilotList { get; set; }
    }
}