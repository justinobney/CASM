using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Jobney.Casm.Domain.Entities;
using Jobney.Casm.Web.ViewModels;
using Jobney.Casm.Web.ViewModels.Manage;
using tcdev.Core.Data;

namespace Jobney.Casm.Web.Controllers
{
    public class PassengerController : BaseController
    {
        private readonly IRepository<Passenger> passengerRepository;

        public PassengerController(IRepository<Passenger> passengerRepository)
        {
            this.passengerRepository = passengerRepository;
        }

        public ActionResult GetById(int id)
        {
            var entity = passengerRepository.Query().FirstOrDefault(x => x.Id == id);
            return JsonResult(entity);
        }

        public ActionResult Query()
        {
            var entities = passengerRepository.Query();
            return JsonResult(entities);
        }

        [HttpPost]
        public ActionResult Save(ManagePassengerViewModel passenger)
        {
            var model = Mapper.Map<Passenger>(passenger);
            passengerRepository.InsertOrUpdate(model);
            passengerRepository.CommitChanges();

            return JsonResult(model);
        }
    }
}