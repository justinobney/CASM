using System.Collections.Generic;
using Jobney.Core.Domain;

namespace Jobney.Casm.Domain
{
    public class Airplane:Entity
    {
        public string Name { get; set; }
        public string CallSign { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public List<Pilot> DefaultPilotList { get; set; }
    }
}