using System.Web.Mvc;
using Jobney.Casm.Domain;
using Jobney.Casm.Web.Models;
using Jobney.Casm.Web.ViewModels;
using Jobney.Core.Domain.Interfaces;
using Newtonsoft.Json;

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
                Pilots = JsonConvert.SerializeObject(pilotRepository.GetAll(), jsonSettings),
                Passengers = JsonConvert.SerializeObject(passengerRepository.GetAll(), jsonSettings),
                Airplanes = JsonConvert.SerializeObject(airplaneRepository.GetAll(), jsonSettings),
                Settings = JsonConvert.SerializeObject(new CasmSettingsViewModel(), jsonSettings)
            };
        }
    }
}