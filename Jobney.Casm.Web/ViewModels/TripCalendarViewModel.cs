using System.Collections.Generic;
using Jobney.Casm.Domain;

namespace Jobney.Casm.Web.ViewModels
{
    public class TripCalendarViewModel
    {
        public string TripsJson { get; set; }
        public IEnumerable<Airplane> Airplanes { get; set; }
    }
}