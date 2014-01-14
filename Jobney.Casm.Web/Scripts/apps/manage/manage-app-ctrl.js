(function () {
    'use strict';

    var app = angular.module('Jobney.Casm.ManageApp');

    app.controller('ManageAppCtrl', [
        '$scope', '$state',
        function($scope, $state) {
            $scope.activeClass = function(state) {
                return $state.is(state) ? 'active' : '';
            };
        }
    ]);

    app.controller('ManageAirplanesCtrl', [
            '$scope', 'BootstrappedData',
            function ($scope, BootstrappedData) {
                $scope.airplanes = BootstrappedData.airplanes;
            }
        ]
    );

    app.controller('SettingsCtrl', [
            '$scope', 'BootstrappedData',
            function ($scope, BootstrappedData) {
                $scope.settings = BootstrappedData.settings;
            }
        ]
    ); 
})();