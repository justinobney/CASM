using System.Collections.Generic;
using System.Linq;
using Jobney.Casm.Domain;

namespace Jobney.Casm.Services
{
    public class TripService
    {
        public void ReorderWaypoints(Trip trip, int wpId, int newOrder)
        {
            var changingWaypoints = trip.Waypoints.Where(w => w.Id != wpId);
            var originalOrder = trip.Waypoints.FirstOrDefault(w => w.Id == wpId).Order;

            // Handle New Order Out Of Range
            if (newOrder > trip.Waypoints.Max(w => w.Order))
                newOrder = trip.Waypoints.Max(w => w.Order);

            // Set order of waypoint in question
            trip.Waypoints.FirstOrDefault(w => w.Id == wpId).Order = newOrder;


            ReorderTopGap(newOrder, changingWaypoints, originalOrder);
            ReorderBottomGap(newOrder, changingWaypoints, originalOrder);
        }

        private void ReorderBottomGap(int newOrder, IEnumerable<Waypoint> changingWaypoints, int originalOrder)
        {
            changingWaypoints = changingWaypoints.Where(w => w.Order <= newOrder && w.Order > originalOrder);

            foreach (var wp in changingWaypoints)
            {
                wp.Order = wp.Order - 1;
            }
        }

        private static void ReorderTopGap(int newOrder, IEnumerable<Waypoint> changingWaypoints, int originalOrder)
        {
            changingWaypoints = changingWaypoints.Where(w => w.Order >= newOrder && w.Order < originalOrder);

            foreach (var wp in changingWaypoints)
            {
                wp.Order = wp.Order + 1;
            }
        }
    }
}
