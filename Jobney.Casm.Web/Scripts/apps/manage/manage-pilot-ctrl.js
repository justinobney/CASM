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
})();