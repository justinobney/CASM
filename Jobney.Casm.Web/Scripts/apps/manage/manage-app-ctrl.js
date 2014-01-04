(function () {
    'use strict';

    var app = angular.module('Jobney.Casm.ManageApp');

    app.controller('ManageAppCtrl', ['$scope', '$state', function ($scope, $state) {
        $scope.activeClass = function(state) {
            return $state.is(state) ? 'active' : '';
        };
    }]);
})();