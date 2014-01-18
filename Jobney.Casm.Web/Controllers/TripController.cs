using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Jobney.Casm.Domain.Entities;
using Jobney.Casm.Services;
using Jobney.Casm.Web.Models;
using Jobney.Casm.Web.ViewModels;
using Newtonsoft.Json;
using tcdev.Core.Data;

namespace Jobney.Casm.Web.Controllers
{
    public class TripController : BaseController
    {
        private readonly IRepository<Trip> tripRepository;
        private readonly IRepository<Waypoint> waypointRepository;
        private readonly ListDataService listData;
        private readonly IRepository<Settings> settingsRepository;
        private readonly TripService tripService;

        public TripController(IRepository<Trip> tripRepository,
                              IRepository<Waypoint> waypointRepository,
                              ListDataService listData,
                              IRepository<Settings> settingsRepository,
                              TripService tripService)
        {
            this.tripRepository = tripRepository;
            this.waypointRepository = waypointRepository;
            this.listData = listData;
            this.settingsRepository = settingsRepository;
            this.tripService = tripService;
        }

        private TripInfoDataBootstrapper BootstrapData()
        {
            return new TripInfoDataBootstrapper
            {
                Airplanes = JsonConvert.SerializeObject(listData.Airplanes.Query().ToList(), jsonSettings),
                Passengers = JsonConvert.SerializeObject(listData.Passengers.Query().ToList(), jsonSettings)
            };
        }
        
        public ActionResult Info()
        {
            var bootstrapData = BootstrapData();
            return View(bootstrapData);
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

            if (waypoint.PassengerIds != null)
            {
                foreach (var passengerId in waypoint.PassengerIds)
                {
                    entity.Passengers.Add(
                        new WaypointPassenger
                        {
                            TripId = waypoint.TripId,
                            PassengerId = passengerId
                        });
                }
            }

            waypointRepository.InsertOrUpdate(entity);
            waypointRepository.CommitChanges();

            return JsonResult(new {Success = true, entity});
        }

        [HttpPost]
        public ActionResult QuickAdd(TripQuickAddViewModel vm)
        {
            var trip = new Trip
            {
                StatusId = 1,
                AirplaneId = vm.AirplaneId,
                Name = vm.TripName,
                Waypoints = new Collection<Waypoint>()
            };
            trip.Waypoints.Add(QuickAddDepartingWaypoint(vm));
            trip.Waypoints.Add(QuickAddArrivingWaypoint(vm));
            tripRepository.InsertOrUpdate(trip);
            tripRepository.CommitChanges();

            return JsonResult(new { Success = true, trip });
        }
        
        [HttpPost]
        public ActionResult ReorderWaypoint(int id, int waypointId, int newOrder)
        {
            var trip = tripRepository.Query()
                .Include(t => t.Waypoints)
                .FirstOrDefault(t => t.Id == id);
            
            tripService.ReorderWaypoints(trip, waypointId, newOrder);
            tripRepository.InsertOrUpdate(trip);
            tripRepository.CommitChanges();
            
            var tripOrderMap = trip.Waypoints.Select(wp => new {wp.Id, wp.Order });

            return JsonResult(new {Success = true, tripOrderMap});
        }

        private Waypoint QuickAddDepartingWaypoint(TripQuickAddViewModel vm)
        {
            var settings = settingsRepository.Query().ToList();
            return new Waypoint
            {
                Order = 1,
                City = settings.First(s => s.Key == "City").Value,
                State = settings.First(s => s.Key == "State").Value,
                Departing = vm.DepartingDate
            };
        }

        private Waypoint QuickAddArrivingWaypoint(TripQuickAddViewModel vm)
        {
            return new Waypoint
            {
                Order = 2,
                City = vm.City,
                State = vm.State,
                Arriving = vm.DepartingDate
            };
        }
    }
}