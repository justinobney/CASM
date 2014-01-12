(function() {
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
    };

    function addNewTrip() {
        var data = {
            tripName: $('#NewTripTitle').val(),
            departingDate: $('#NewTripDate').val(),
            airplaneId: $('#NewTripAirplane').val()
        };

        $.post(urlMap.tripQuickCreate, data).success(function(response) {
            alert(response.success);
        });

        homeApp.calendar
            .fullCalendar('renderEvent',
                {
                    title: $('#NewTripTitle').val(),
                    start: $('#NewTripDate').val()
                },
                true // make the event "stick"
            );
    }

})()