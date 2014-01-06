(function() {
    'use strict';

    var app = angular.module('Jobney.Casm.SharedServices');

    app.factory('TripService', ['$http',
        function ($http) {

            var service = {};

            service.getTrip = function(id) {
                
            };

            return service;
        }
    ]);
})()