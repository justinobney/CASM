using System.Web.Mvc;
using Jobney.Casm.Domain;
using Jobney.Core.Domain.Interfaces;

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
            return View();
        }
    }
}