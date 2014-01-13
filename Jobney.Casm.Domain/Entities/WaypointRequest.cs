using tcdev.Core.Domain;

namespace Jobney.Casm.Domain.Entities
{
    public class WaypointRequest : EntityBase
    {
        public string Description { get; set; }
        public string Responsible { get; set; }
        public string Notes { get; set; }
        public bool Complete { get; set; }

        public int TypeId { get; set; }
        public WaypointRequestType Type { get; set; }

        public int WaypointId { get; set; }
        public Waypoint Waypoint { get; set; }
    }
}