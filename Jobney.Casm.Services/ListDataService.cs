using Jobney.Casm.Domain.Entities;
using tcdev.Core.Data;

namespace Jobney.Casm.Services
{
    public class ListDataService
    {
        public readonly IRepository<Pilot> Pilots;
        public readonly IRepository<Passenger> Passengers;
        public readonly IRepository<Airplane> Airplanes;

        public ListDataService(IRepository<Pilot> pilotRepository, IRepository<Passenger> passengerRepository, IRepository<Airplane> airplaneRepository)
        {
            Pilots = pilotRepository;
            Passengers = passengerRepository;
            Airplanes = airplaneRepository;
        }
    }
}