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

                $scope.airplanes = BootstrappedData.airplanes;

                $scope.sortableOptions = {
                    placeholder: "drop-placeholder",
                    update: function (e, ui) {
                        setTimeout(function() {
                            var waypointId = ui.item.scope().location.id;
                            var newOrder = ui.item.index() + 1;
                            var tripId = $scope.trip.id;

                            TripService.ReorderWaypoint(tripId, waypointId, newOrder).then(function(response) {
                                _.each($scope.trip.waypoints, function (wp, idx) {
                                    wp.order = _.findWhere(response.tripOrderMap, { id: wp.id }).order;
                                });
                            });
                        }, 0);
                    },
                    revert: true,
                    handle: ".drag-handle"
                };
            }

        }
    ]);
})()