using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Jobney.Casm.Domain;
using Jobney.Casm.Services;
using Jobney.Casm.Web.Models;
using Jobney.Core;
using Jobney.Core.Domain.Interfaces;
using Newtonsoft.Json;

namespace Jobney.Casm.Web.Controllers
{
    public class TripController : BaseController
    {
        private readonly IRepository<Trip> tripRepository;
        private readonly IRepository<Airplane> airplaneRepository;
        private readonly TripService tripService;

        public TripController(IRepository<Trip> tripRepository, IRepository<Airplane> airplaneRepository, TripService tripService)
        {
            this.tripRepository = tripRepository;
            this.airplaneRepository = airplaneRepository;
            this.tripService = tripService;
        }

        public ActionResult Info()
        {
            var bootstrapData = BootstrapData();
            return View(bootstrapData);
        }

        private TripInfoDataBootstrapper BootstrapData()
        {
            return new TripInfoDataBootstrapper
            {
                Airplanes = JsonConvert.SerializeObject(airplaneRepository.GetAll().ToList(), jsonSettings)
            };
        }

        public ActionResult GetById(int id)
        {
            var model = tripRepository
                .Query()
                .Include(t=>t.Waypoints)
                .Include(t=>t.Waypoints.Select(wp=>wp.SpecialRequests))
                .FirstOrDefault(t=>t.Id == id);

            model.Waypoints = model.Waypoints.OrderBy(wp => wp.Order).ToList();

            return JsonResult(model);
        }

        [HttpPost]
        public ActionResult ReorderWaypoint(int id, int waypointId, int newOrder)
        {
            var trip = tripRepository.Query()
                .Include(t => t.Waypoints)
                .FirstOrDefault(t => t.Id == id);
            
            tripService.ReorderWaypoints(trip, waypointId, newOrder);
            tripRepository.InsertOrUpdate(trip);
            uow.SaveChanges();
            
            var tripOrderMap = trip.Waypoints.Select(wp => new {wp.Id, wp.Order });

            return JsonResult(new {Success = true, tripOrderMap});
        }
    }
}