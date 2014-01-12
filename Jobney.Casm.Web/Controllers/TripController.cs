using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Jobney.Casm.Domain;
using Jobney.Casm.Services;
using Jobney.Casm.Web.Models;
using Jobney.Casm.Web.ViewModels;
using Jobney.Core;
using Jobney.Core.Domain.Interfaces;
using Newtonsoft.Json;

namespace Jobney.Casm.Web.Controllers
{
    public class TripController : BaseController
    {
        private readonly IRepository<Trip> tripRepository;
        private readonly IRepository<Waypoint> waypointRepository; 
        private readonly IRepository<Airplane> airplaneRepository;
        private readonly IRepository<Passenger> passengerRepository;
        private readonly TripService tripService;

        public TripController(IRepository<Trip> tripRepository,
                              IRepository<Waypoint> waypointRepository,
                              IRepository<Airplane> airplaneRepository, 
                              IRepository<Passenger> passengerRepository, 
                              TripService tripService)
        {
            this.tripRepository = tripRepository;
            this.waypointRepository = waypointRepository;
            this.airplaneRepository = airplaneRepository;
            this.passengerRepository = passengerRepository;
            this.tripService = tripService;
        }

        public ActionResult Info()
        {
            var bootstrapData = BootstrapData();
            return View(bootstrapData);
        }

        private TripInfoDataBootstrapper BootstrapData()
        {
            return new TripInfoDataBootstrapper
            {
                Airplanes = JsonConvert.SerializeObject(airplaneRepository.GetAll().ToList(), jsonSettings),
                Passengers = JsonConvert.SerializeObject(passengerRepository.GetAll().ToList(), jsonSettings)
            };
        }

        public ActionResult GetById(int id)
        {
            var model = tripRepository
                .Query()
                .Include(t=>t.Waypoints)
                .Include(t=>t.Waypoints.Select(wp=>wp.SpecialRequests))
                .FirstOrDefault(t=>t.Id == id);

            model.Waypoints = model.Waypoints.OrderBy(wp => wp.Order).ToList();

            return JsonResult(model);
        }

        [HttpPost]
        public ActionResult CreateWaypoint(NewWaypointViewModel waypoint)
        {
            var trip = tripRepository
                .Query()
                .Include(t => t.Waypoints)
                .FirstOrDefault(t => t.Id == waypoint.TripId);

            if (trip == null)
            {
                return JsonResult(new {Success = false});
            }
            
            if (!ModelState.IsValid) {
                return JsonResult(new {Success = false, ModelState});
            }

            var entity = new Waypoint {
                TripId = waypoint.TripId,
                City = waypoint.City,
                State = waypoint.State,
                Passengers = new List<WaypointPassenger>(),
                Order = trip.Waypoints.Max(x=>x.Order) + 1
            };

            foreach (var passengerId in waypoint.PassengerIds) {
                entity.Passengers.Add(
                    new WaypointPassenger {
                        PassengerId = passengerId
                    });
            }

            waypointRepository.InsertOrUpdate(entity);
            uow.SaveChanges();

            return JsonResult(new {Success = true, entity});
        }

        [HttpPost]
        public ActionResult ReorderWaypoint(int id, int waypointId, int newOrder)
        {
            var trip = tripRepository.Query()
                .Include(t => t.Waypoints)
                .FirstOrDefault(t => t.Id == id);
            
            tripService.ReorderWaypoints(trip, waypointId, newOrder);
            tripRepository.InsertOrUpdate(trip);
            uow.SaveChanges();
            
            var tripOrderMap = trip.Waypoints.Select(wp => new {wp.Id, wp.Order });

            return JsonResult(new {Success = true, tripOrderMap});
        }
    }
}