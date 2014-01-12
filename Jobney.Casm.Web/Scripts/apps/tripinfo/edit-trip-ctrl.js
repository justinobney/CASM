(function() {
    'use strict';

    var app = angular.module('Jobney.Casm.TripInfoApp');

    app.controller('EditTripCtrl', ['$scope', '$stateParams', 'TripService', 'BootstrappedData',
        function ($scope, $stateParams, TripService, BootstrappedData) {

            $scope.addStop = function() {
                var convertedPlace = convertPlaceResultToPlace($scope.details);

                var newWaypoint = {
                    tripId: $scope.trip.id,
                    city: convertedPlace.locality,
                    state: convertedPlace.state,
                    passengerIds: $scope.passengers
                };

                TripService.addWaypoint(newWaypoint);
            };

            activate();

            function activate() {
                TripService.getById($stateParams.id).then(function(trip) {
                    $scope.trip = trip;
                });

                $scope.sortableOptions = {
                    placeholder: "drop-placeholder",
                    update: function (e, ui) {
                        setTimeout(function() {
                            var waypointId = ui.item.scope().location.id;
                            var newOrder = ui.item.index() + 1;
                            handleWaypointReorder(waypointId, newOrder);
                        }, 0);
                    },
                    revert: true,
                    handle: ".drag-handle"
                };

                $scope.airplanes = BootstrappedData.airplanes;
                $scope.passengerList = _.map(BootstrappedData.passengers, function(p) {
                    return { id: p.id, text: p.firstName + ' ' + p.lastName };
                });

                $scope.select2Options = {};
                $scope.ngAutocompleteOptions = {};
                $scope.tripMapOptions = {
                    center: new google.maps.LatLng(30.450, -91.140),
                    panControl: false,
                    zoomControl: false,
                    mapTypeControl: false,
                    overviewMapControl: false,
                    rotateControl: false,
                    scaleControl: false,
                    streetViewControl: false,
                    styles: [{ "featureType": "water", "stylers": [{ "visibility": "on" }, { "color": "#acbcc9" }] }, { "featureType": "landscape", "stylers": [{ "color": "#f2e5d4" }] }, { "featureType": "road.highway", "elementType": "geometry", "stylers": [{ "color": "#c5c6c6" }] }, { "featureType": "road.arterial", "elementType": "geometry", "stylers": [{ "color": "#e4d7c6" }] }, { "featureType": "road.local", "elementType": "geometry", "stylers": [{ "color": "#fbfaf7" }] }, { "featureType": "poi.park", "elementType": "geometry", "stylers": [{ "color": "#c5dac6" }] }, { "featureType": "administrative", "stylers": [{ "visibility": "on" }, { "lightness": 33 }] }, { "featureType": "road" }, { "featureType": "poi.park", "elementType": "labels", "stylers": [{ "visibility": "on" }, { "lightness": 20 }] }, {}, { "featureType": "road", "stylers": [{ "lightness": 20 }] }]
                };

                setupWatches();
            }

            function convertPlaceResultToPlace(placeResult) {
                var place = {
                    streetNumber: find('street_number'),
                    route: find('route'),
                    locality: find('locality'),
                    state: find('administrative_area_level_1'),
                    country: find('country'),
                    postalCode: find('postal_code')
                };

                return place;

                function find(typeName) {
                    var found = _.find(placeResult.address_components, function (val) {
                        return val.types.indexOf(typeName) > -1;
                    });

                    return (found) ? found.long_name : '';
                }
            };

            function handleWaypointReorder(waypointId, newOrder) {
                var tripId = $scope.trip.id;

                TripService.ReorderWaypoint(tripId, waypointId, newOrder).then(function (response) {
                    _.each($scope.trip.waypoints, function (wp, idx) {
                        wp.order = _.findWhere(response.tripOrderMap, { id: wp.id }).order;
                    });
                });
            };

            function setupWatches() {
                $scope.$watch(function () { return $scope.details; }, handleDetailsUpdate);
            }

            function handleDetailsUpdate(newVal, oldVal, scope) {
                if (newVal && newVal.geometry)
                    $scope.center = newVal.geometry.location;
            }
        }
    ]);
})()