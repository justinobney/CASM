(function() {
    'use strict';

    var app = angular.module('Jobney.Casm.TripInfoApp');

    app.controller('EditTripCtrl', ['$scope', '$stateParams', 'TripService',
        function ($scope, $stateParams, TripService) {

            $scope.handleRowClick = function(open) {
                $scope.min = true;
                return !open;
            };

            activate();

            function activate() {
                TripService.getById($stateParams.id).then(function(trip) {
                    $scope.trip = trip;
                });
            }

        }
    ]);
})()