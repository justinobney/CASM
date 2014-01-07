(function() {
    'use strict';

    var app = angular.module('Jobney.Casm.TripInfoApp');

    app.controller('EditTripCtrl', ['$scope', '$stateParams', 'TripService',
        function ($scope, $stateParams, TripService) {

            activate();

            function activate() {
                TripService.getById($stateParams.id).then(function(trip) {
                    $scope.data = trip;
                });
            }

        }
    ]);
})()