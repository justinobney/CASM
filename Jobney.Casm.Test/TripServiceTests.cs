using Jobney.Casm.Domain;
using Jobney.Casm.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.Casm.Tests
{
    [TestClass]
    public class TripServiceTests
    {

        private TripService service;

        [TestInitialize]
        public void Init()
        {
            service = new TripService();
        }

        [TestMethod]
        public void ReorderTripWaypointsSetsWaypointOrder()
        {
            var trip = TestDataGenerator.GetTrip(); // Should return trip w/ 3 waypoints
            trip.Waypoints.ToArray()[0].Order = 1;
            trip.Waypoints.ToArray()[1].Order = 2;
            trip.Waypoints.ToArray()[2].Order = 3;

            var waypointInQuestion = trip.Waypoints.ToArray()[1];
            var newIndex = 1;

            service.ReorderWaypoints(trip, waypointInQuestion.Id, newIndex);

            Assert.AreEqual(waypointInQuestion.Order, newIndex);
        }

        [TestMethod]
        public void ReorderTripWaypointsReordersWhenSetToFirst()
        {
            var trip = TestDataGenerator.GetTrip(); // Should return trip w/ 3 waypoints
            trip.Waypoints.ToArray()[0].Order = 1;
            trip.Waypoints.ToArray()[1].Order = 2;
            trip.Waypoints.ToArray()[2].Order = 3;

            var waypointInQuestion = trip.Waypoints.ToArray()[1];

            service.ReorderWaypoints(trip, waypointInQuestion.Id, 1);

            Assert.AreEqual(trip.Waypoints.ToArray()[0].Order, 2);
            Assert.AreEqual(trip.Waypoints.ToArray()[1].Order, 1);
            Assert.AreEqual(trip.Waypoints.ToArray()[2].Order, 3);
        }

        [TestMethod]
        public void ReorderTripWaypointsReordersWhenSetToLast()
        {
            var trip = TestDataGenerator.GetTrip(); // Should return trip w/ 3 waypoints
            trip.Waypoints.ToArray()[0].Order = 1;
            trip.Waypoints.ToArray()[1].Order = 2;
            trip.Waypoints.ToArray()[2].Order = 3;

            var waypointInQuestion = trip.Waypoints.ToArray()[1];

            service.ReorderWaypoints(trip, waypointInQuestion.Id, 3);

            Assert.AreEqual(trip.Waypoints.ToArray()[0].Order, 1);
            Assert.AreEqual(trip.Waypoints.ToArray()[1].Order, 3);
            Assert.AreEqual(trip.Waypoints.ToArray()[2].Order, 2);
        }

        [TestMethod]
        public void ReorderTripWaypointsHandleOutOfRangeReorder()
        {
            var trip = TestDataGenerator.GetTrip(); // Should return trip w/ 3 waypoints
            trip.Waypoints.ToArray()[0].Order = 1;
            trip.Waypoints.ToArray()[1].Order = 2;
            trip.Waypoints.ToArray()[2].Order = 3;

            var waypointInQuestion = trip.Waypoints.ToArray()[1];

            service.ReorderWaypoints(trip, waypointInQuestion.Id, 6);

            Assert.AreEqual(trip.Waypoints.ToArray()[0].Order, 1);
            Assert.AreEqual(trip.Waypoints.ToArray()[1].Order, 3);
            Assert.AreEqual(trip.Waypoints.ToArray()[2].Order, 2);
        }
    }
}
