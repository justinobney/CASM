using Jobney.Core.Domain;

namespace Jobney.Casm.Domain
{
    public class WaypointPassenger:Entity
    {
        public int WaypointId { get; set; }
        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}