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
        private readonly IRepository<Airplane> airplaneRepository;

        public HomeController(IRepository<Trip> tripRepository, IRepository<Airplane> airplaneRepository)
        {
            this.tripRepository = tripRepository;
            this.airplaneRepository = airplaneRepository;
        }

        public ActionResult Index()
        {
            var vm = new TripCalendarViewModel
            {
                TripsJson = JsonConvert.SerializeObject(GetTrips(), jsonSettings),
                Airplanes = airplaneRepository.GetAll()
            };
            return View(vm);
        }

        private IEnumerable<FullCalendarViewModel> GetTrips()
        {
            return tripRepository
                .Query()
                .OrderByDescending(t=>t.Id)
                .Select(t => new FullCalendarViewModel
                {
                    Id = t.Id,
                    Title = t.Name,
                    Start = t.Waypoints.Min(wp => wp.Departing),
                    End = t.Waypoints.Max(wp => wp.Arriving)
                })
                .Take(500)
                .ToList()
                .Select(t =>
                {
                    t.Url = string.Format("{0}#/edit/{1}", Url.Action("Info", "Trip"), t.Id);
                    return t;
                });
        }
    }
}