using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jobney.Casm.Web.ViewModels
{
    public class NewWaypointViewModel
    {
        [Range(1, int.MaxValue)]
        public int TripId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string State { get; set; }
        
        public IEnumerable<int> PassengerIds { get; set; }
    }
}