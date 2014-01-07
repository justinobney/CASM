using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Jobney.Casm.Domain;
using Jobney.Core.Domain.Interfaces;

namespace Jobney.Casm.Web.Controllers
{
    public class TripController : BaseController
    {
        private readonly IRepository<Trip> tripRepository;

        public TripController(IRepository<Trip> tripRepository )
        {
            this.tripRepository = tripRepository;
        }

        public ActionResult Info()
        {
            return View();
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
    }
}