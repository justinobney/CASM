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

    app.controller('ManagePilotsCtrl', [
            '$scope', 'BootstrappedData',
            function($scope, BootstrappedData) {
                $scope.pilots = BootstrappedData.pilots;
            }
        ]
    );

    app.controller('ManagePassengersCtrl', [
            '$scope', 'BootstrappedData',
            function ($scope, BootstrappedData) {
                $scope.passengers = BootstrappedData.passengers;
            }
        ]
    );

    app.controller('ManageAirplanesCtrl', [
            '$scope', 'BootstrappedData',
            function ($scope, BootstrappedData) {
                $scope.airplanes = BootstrappedData.airplanes;
            }
    ]
    );
})();