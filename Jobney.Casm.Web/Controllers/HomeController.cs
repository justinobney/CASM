using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Jobney.Casm.Domain;
using Jobney.Casm.Web.ViewModels;
using Jobney.Core.Domain.Interfaces;
using Newtonsoft.Json;

namespace Jobney.Casm.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRepository<Trip> tripRepository;

        public HomeController(IRepository<Trip> tripRepository)
        {
            this.tripRepository = tripRepository;
        }

        public ActionResult Index()
        {
            var vm = new TripCalendarViewModel
            {
                TripsJson = JsonConvert.SerializeObject(GetMonthTrips(), jsonSettings)
            };
            return View(vm);
        }

        private IEnumerable<FullCalendarViewModel> GetMonthTrips()
        {
            return tripRepository
                .Query()
                .Where(t => t.Waypoints.Any(arg => (arg.Arriving.HasValue && arg.Arriving.Value.Month == DateTime.Now.Month) ||
                   (arg.Departing.HasValue && arg.Departing.Value.Month == DateTime.Now.Month)))
                .Select(t => new FullCalendarViewModel
                {
                    Title = t.Name,
                    Start = t.Waypoints.Min(wp => wp.Departing),
                    End = t.Waypoints.Max(wp => wp.Arriving)
                }).ToList();
        }
    }
}