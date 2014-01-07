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

            return service;
        }
    ]);
})()