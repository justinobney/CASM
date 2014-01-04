using System.Web.Mvc;
using Jobney.Casm.Domain;
using Jobney.Casm.Web.Models;
using Jobney.Core.Domain.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jobney.Casm.Web.Controllers
{
    public class ManageController : Controller
    {
        private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        private readonly IRepository<Pilot> pilotRepository;
        private readonly IRepository<Passenger> passengerRepository;

        public ManageController(IRepository<Pilot> pilotRepository, IRepository<Passenger> passengerRepository )
        {
            this.pilotRepository = pilotRepository;
            this.passengerRepository = passengerRepository;
        }

        // GET: /Manage/
        public ActionResult Index()
        {
            var boostrapedData = BoostrapData();
            return View(boostrapedData);
        }

        private ManageDataBootstrapper BoostrapData()
        {
            return new ManageDataBootstrapper
            {
                Pilots = JsonConvert.SerializeObject(pilotRepository.GetAll(), jsonSettings),
                Passengers = JsonConvert.SerializeObject(passengerRepository.GetAll(), jsonSettings)
            };
        }
    }
}