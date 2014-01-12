using System;

namespace Jobney.Casm.Web.ViewModels
{
    public class TripQuickAddViewModel
    {
        public string TripName { get; set; }
        public DateTime DepartingDate { get; set; }
        public int AirplaneId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}