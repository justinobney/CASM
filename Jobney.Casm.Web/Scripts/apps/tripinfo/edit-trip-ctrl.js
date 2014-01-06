(function() {
    'use strict';

    var app = angular.module('Jobney.Casm.TripInfoApp');

    app.controller('EditTripCtrl', [
        '$scope', function($scope) {

            activate();

            function activate() {
                $scope.data = 42;
            }

        }
    ]);
})()