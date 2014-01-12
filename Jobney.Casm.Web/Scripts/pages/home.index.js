(function() {
    'use strict';
    var homeApp = window.homeApp = {};

    homeApp.init = function (events) {
        homeApp.events = events;
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
        $(document).on('click', '[data-action="add-trip"]', function (e) {
            //code here
            homeApp.calendar
                .fullCalendar('renderEvent',
                    {
                        title: $('#NewTripTitle').val(),
                        start: $('#NewTripDate').val()
                    },
                    true // make the event "stick"
                );
        });
    };
})()