(function() {
    'use strict';

    var app = angular.module('Jobney.Casm.SharedServices');

    app.factory('PilotService', [
            '$http', 'ServiceRoutes',
            function($http, ServiceRoutes) {
                var service = {};

                service.pilots = [];

                service.newPilot = function() {
                    return {
                        id: 0,
                        firstName: '',
                        lastName: '',
                        emailAddress: '',
                        phoneNumber: ''
                    };
                };

                service.getById = function (id) {
                    var url = ServiceRoutes.pilot.getById + id;

                    return $http.get(url).then(function (response) {
                        return response.data;
                    });
                };

                service.query = function () {
                    var url = ServiceRoutes.pilot.query;

                    return $http.get(url).then(function (response) {
                        return response.data;
                    });
                };

                service.save = function (pilot) {
                    var url = ServiceRoutes.pilot.save;

                    return $http.post(url, pilot).then(function (response) {
                        return response.data;
                    });
                };

                return service;
            }
        ]
    );
})();