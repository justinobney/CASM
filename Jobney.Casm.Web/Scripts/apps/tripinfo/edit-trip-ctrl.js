(function() {
    'use strict';

    var app = angular.module('Jobney.Casm.TripInfoApp');

    app.controller('EditTripCtrl', ['$scope', '$stateParams', 'TripService', 'BootstrappedData',
        function ($scope, $stateParams, TripService, BootstrappedData) {
            
            activate();

            function activate() {
                TripService.getById($stateParams.id).then(function(trip) {
                    $scope.trip = trip;
                });

                $scope.sortableOptions = {
                    placeholder: "drop-placeholder",
                    update: function (e, ui) {
                        setTimeout(function() {
                            var waypointId = ui.item.scope().location.id;
                            var newOrder = ui.item.index() + 1;
                            handleWaypointReorder(waypointId, newOrder);
                        }, 0);
                    },
                    revert: true,
                    handle: ".drag-handle"
                };

                $scope.airplanes = BootstrappedData.airplanes;
                $scope.passengerList = _.map(BootstrappedData.passengers, function(p) {
                    return { id: p.id, text: p.firstName + ' ' + p.lastName };
                });

                $scope.select2Options = {};
                $scope.ngAutocompleteOptions = {};

                setupWatches();
            }

            function handleWaypointReorder(waypointId, newOrder) {
                var tripId = $scope.trip.id;

                TripService.ReorderWaypoint(tripId, waypointId, newOrder).then(function (response) {
                    _.each($scope.trip.waypoints, function (wp, idx) {
                        wp.order = _.findWhere(response.tripOrderMap, { id: wp.id }).order;
                    });
                });
            };

            function setupWatches() {
                $scope.$watch(function () { return $scope.details; }, handleDetailsUpdate);
            }

            function handleDetailsUpdate(newVal, oldVal, scope) {
                if (newVal && newVal.geometry)
                    $scope.center = newVal.geometry.location;
            }

        }
    ]);
})()