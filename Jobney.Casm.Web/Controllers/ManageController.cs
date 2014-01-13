using System.Linq;
using System.Web.Mvc;
using Jobney.Casm.Domain.Entities;
using Jobney.Casm.Web.Models;
using Jobney.Casm.Web.ViewModels;
using Newtonsoft.Json;
using tcdev.Core.Data;

namespace Jobney.Casm.Web.Controllers
{
    public class ManageController : BaseController
    {
        private readonly IRepository<Pilot> pilotRepository;
        private readonly IRepository<Passenger> passengerRepository;
        private readonly IRepository<Airplane> airplaneRepository;

        public ManageController(IRepository<Pilot> pilotRepository, IRepository<Passenger> passengerRepository, IRepository<Airplane> airplaneRepository)
        {
            this.pilotRepository = pilotRepository;
            this.passengerRepository = passengerRepository;
            this.airplaneRepository = airplaneRepository;
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
                Settings = JsonConvert.SerializeObject(new CasmSettingsViewModel(), jsonSettings)
            };
        }
    }
}