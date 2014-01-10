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
            }

        }
    ]);
})()