using System.Linq;
using System.Web.Mvc;
using Jobney.Casm.Domain.Entities;
using Jobney.Casm.Web.Models;
using Newtonsoft.Json;
using tcdev.Core.Data;

namespace Jobney.Casm.Web.Controllers
{
    public class ManageController : BaseController
    {
        private readonly IRepository<Pilot> pilotRepository;
        private readonly IRepository<Passenger> passengerRepository;
        private readonly IRepository<Airplane> airplaneRepository;
        private readonly IRepository<Settings> settingsRepository;

        public ManageController(
            IRepository<Pilot> pilotRepository, 
            IRepository<Passenger> passengerRepository, 
            IRepository<Airplane> airplaneRepository,
            IRepository<Settings> settingsRepository)
        {
            this.pilotRepository = pilotRepository;
            this.passengerRepository = passengerRepository;
            this.airplaneRepository = airplaneRepository;
            this.settingsRepository = settingsRepository;
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
                Pilots = JsonConvert.SerializeObject(pilotRepository.Query().ToList(), jsonSettings),
                Passengers = JsonConvert.SerializeObject(passengerRepository.Query().ToList(), jsonSettings),
                Airplanes = JsonConvert.SerializeObject(airplaneRepository.Query().ToList(), jsonSettings),
                Settings = JsonConvert.SerializeObject(settingsRepository.Query().ToList(), jsonSettings)
            };
        }
    }
}