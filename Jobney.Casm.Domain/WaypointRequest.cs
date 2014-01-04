using Jobney.Core.Domain;

namespace Jobney.Casm.Domain
{
    public class WaypointRequest:Entity
    {
        public WaypointRequestType Type { get; set; }
        public string Responsible { get; set; }
        public string Notes { get; set; }
        public bool Complete { get; set; }
    }
}