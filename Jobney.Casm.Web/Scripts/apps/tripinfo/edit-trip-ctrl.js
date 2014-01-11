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
                            var scope = ui.item.scope();
                            var tripId = scope.trip.id;
                            var waypointId = scope.location.id;
                            var newOrder = ui.item.index() + 1;
                            TripService.ReorderWaypoint(tripId, waypointId, newOrder).then(function(response) {
                                console.log(response);
                            });
                        }, 0);
                        // ui.item.scope().location
                    },
                    revert: true,
                    handle: ".drag-handle"
                };
            }

        }
    ]);
})()