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
    }
}