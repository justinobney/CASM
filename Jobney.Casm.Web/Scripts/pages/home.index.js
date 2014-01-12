(function () {
    'use strict';
    var homeApp = window.homeApp = {};
    var urlMap = {};

    homeApp.init = function (events, urls) {
        homeApp.events = events;
        urlMap = urls;

        bindEvents();
        initCalendar();

        $('#NewTripDate').datepicker({});
    };

    function initCalendar() {
        homeApp.calendar = $('#calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: ''
            },
            selectable: true,
            selectHelper: true,
            events: homeApp.events
        });
    }

    function bindEvents() {
        $(document).on('click', '[data-action="add-trip"]', addNewTrip);

        $("#NewTripDestination").geocomplete({
            details: ".trip-quick-add"
        });
    };

    function addNewTrip() {
        var data = {
            tripName: $('#NewTripTitle').val(),
            departingDate: $('#NewTripDate').val(),
            airplaneId: $('#NewTripAirplane').val(),
            city: $('#NewTripCity').val(),
            state: $('#NewTripState').val()
        };

        $.post(urlMap.tripQuickCreate, data).success(function (response) {
            if (response.success) {
                homeApp.calendar
                    .fullCalendar('renderEvent',
                        {
                            title: $('#NewTripTitle').val(),
                            start: $('#NewTripDate').val()
                        },
                        true // make the event "stick"
                    );
            }
        });
    }

})()