using System.Web.Mvc;
using Jobney.Casm.Domain;
using Jobney.Casm.Web.Helpers;
using Jobney.Core.Domain.Interfaces;

namespace Jobney.Casm.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRepository<Pilot> pilotRepository;

        public HomeController(IRepository<Pilot> pilotRepository)
        {
            this.pilotRepository = pilotRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonNetResult Pilots()
        {
            var pilots = pilotRepository.GetAll();
            return JsonResult(pilots);
        }
    }
}