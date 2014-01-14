using System.Linq;
using System.Web.Mvc;
using Jobney.Casm.Domain.Entities;
using Jobney.Casm.Services;
using Jobney.Casm.Web.Models;
using Newtonsoft.Json;
using tcdev.Core.Data;

namespace Jobney.Casm.Web.Controllers
{
    public class ManageController : BaseController
    {
        private readonly ListDataService listData;
        private readonly IRepository<Settings> settingsRepository;

        public ManageController(ListDataService listData, IRepository<Settings> settingsRepository)
        {
            this.listData = listData;
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
                Pilots = JsonConvert.SerializeObject(listData.Pilots.Query().ToList(), jsonSettings),
                Passengers = JsonConvert.SerializeObject(listData.Passengers.Query().ToList(), jsonSettings),
                Airplanes = JsonConvert.SerializeObject(listData.Airplanes.Query().ToList(), jsonSettings),
                Settings = JsonConvert.SerializeObject(settingsRepository.Query().ToList(), jsonSettings)
            };
        }
    }
}