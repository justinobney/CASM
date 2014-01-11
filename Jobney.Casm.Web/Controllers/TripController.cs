using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Jobney.Casm.Domain;
using Jobney.Casm.Web.Models;
using Jobney.Core.Domain.Interfaces;
using Newtonsoft.Json;

namespace Jobney.Casm.Web.Controllers
{
    public class TripController : BaseController
    {
        private readonly IRepository<Trip> tripRepository;
        private readonly IRepository<Airplane> airplaneRepository;

        public TripController(IRepository<Trip> tripRepository, IRepository<Airplane> airplaneRepository)
        {
            this.tripRepository = tripRepository;
            this.airplaneRepository = airplaneRepository;
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

            return JsonResult(model);
        }

        [HttpPost]
        public ActionResult ReorderWaypoint(int id, int waypointId, int newOrder)
        {
            return JsonResult(new {Success = true});
        }
    }
}