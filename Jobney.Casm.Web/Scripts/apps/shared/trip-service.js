(function() {
    'use strict';

    var app = angular.module('Jobney.Casm.SharedServices');

    app.factory('TripService', ['$http','ServiceRoutes',
        function ($http, ServiceRoutes) {

            var service = {};

            service.getById = function(id) {
                var url = ServiceRoutes.trip.getById + '/' + id;

                return $http.get(url).then(function (response) {
                    return response.data;
                });
            };

            service.ReorderWaypoint = function(tripId, waypointId, newOrder) {
                var url = ServiceRoutes.trip.reorderWaypoint + '/' + tripId;

                var params = {
                    waypointId: waypointId, 
                    newOrder: newOrder
                };

                return $http.post(url, params).then(function (response) {
                    return response.data;
                });
            };

            service.addWaypoint = function (newWaypoint) {
                var url = ServiceRoutes.trip.createWaypoint;

                return $http.post(url, newWaypoint).then(function (response) {
                    return(response.data);
                });
            };

            service.updateWaypoint = function(waypoint) {
                var url = ServiceRoutes.trip.updateWaypoint;

                return $http.post(url, waypoint).then(function (response) {
                    return (response.data);
                });
            };

            service.remove = function (tripId) {
                var url = ServiceRoutes.trip.remove;

                return $http.post(url, { id: tripId }).then(function (response) {
                    return (response.data);
                });
            };

            return service;
        }
    ]);
})()