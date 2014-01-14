using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Jobney.Casm.Domain.Entities;
using Jobney.Casm.Web.ViewModels.Manage;
using tcdev.Core.Data;

namespace Jobney.Casm.Web.Controllers
{
    public class PilotController : BaseController
    {
        private readonly IRepository<Pilot> pilotRepository;

        public PilotController(IRepository<Pilot> pilotRepository)
        {
            this.pilotRepository = pilotRepository;
        }

        public ActionResult GetById(int id)
        {
            var entity = pilotRepository.Query().FirstOrDefault(x => x.Id == id);
            return JsonResult(entity);
        }

        public ActionResult Query()
        {
            var entities = pilotRepository.Query();
            return JsonResult(entities);
        }

        [HttpPost]
        public ActionResult Save(ManagePilotViewModel pilot)
        {
            var model = Mapper.Map<Pilot>(pilot);
            pilotRepository.InsertOrUpdate(model);
            pilotRepository.CommitChanges();

            return JsonResult(model);
        }
    }
}