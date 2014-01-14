(function() {
    'use strict';

    var app = angular.module('Jobney.Casm.ManageApp');
    
    app.controller('ManagePilotsCtrl', [
            '$scope', 'BootstrappedData', 'PilotService',
            function ($scope, BootstrappedData, PilotService) {
                $scope.pilots = BootstrappedData.pilots;

                $scope.savePilot = function() {
                    PilotService.save($scope.activePilot).then(function () {
                        PilotService.query().then(function(data) {
                            $scope.pilots = BootstrappedData.pilots = data;
                            $scope.activePilot = PilotService.newPilot();
                        });
                    });
                };

                $scope.editPilot = function(pilot) {
                    PilotService.getById(pilot.id).then(function (entity) {
                        $scope.activePilot = entity;
                    });
                };

                $scope.cancelEdit = function() {
                    $scope.activePilot = PilotService.newPilot();
                };

                init();
                function init() {
                    $scope.activePilot = PilotService.newPilot();
                    $scope.$watch('activePilot', function(val) {
                        $scope.editing = (val && val.id);
                        $scope.mode = ($scope.editing) ? 'Edit' : 'Create';
                    });
                }

            }
        ]
    );

    app.controller('ManagePassengersCtrl', [
            '$scope', 'BootstrappedData', 'PassengerService',
            function ($scope, BootstrappedData, PassengerService) {
                $scope.passengers = BootstrappedData.passengers;

                $scope.savePassenger = function () {
                    PassengerService.save($scope.activePassenger).then(function () {
                        PassengerService.query().then(function (data) {
                            $scope.passengers = BootstrappedData.passengers = data;
                            $scope.activePassenger = PassengerService.newPassenger();
                        });
                    });
                };

                $scope.editPassenger = function (passenger) {
                    PassengerService.getById(passenger.id).then(function (entity) {
                        $scope.activePassenger = entity;
                    });
                };

                $scope.cancelEdit = function () {
                    $scope.activePassenger = PassengerService.newPassenger();
                };

                init();
                function init() {
                    $scope.activePassenger = PassengerService.newPassenger();
                    $scope.$watch('activePassenger', function (val) {
                        $scope.editing = (val && val.id);
                        $scope.mode = ($scope.editing) ? 'Edit' : 'Create';
                    });
                }

            }
    ]
    );
})();