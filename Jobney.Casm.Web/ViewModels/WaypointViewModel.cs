using System;
using System.ComponentModel.DataAnnotations;

namespace Jobney.Casm.Web.ViewModels
{
    public class WaypointViewModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Zip { get; set; }
        public string Airport { get; set; }
        public string Fbo { get; set; }
        public DateTime? Departing { get; set; }
        public DateTime? Arriving { get; set; }
        public DateTime? Appointment { get; set; }
        public string AppointmentLocation { get; set; }
        public string Notes { get; set; }

        [Range(1, int.MaxValue)]
        public int TripId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string State { get; set; }
    }
}