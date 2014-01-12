(function() {
    'use strict';

    $(document).on('click', '[data-action="add-trip"]', function (e) {
        //code here
        calendar
            .fullCalendar('renderEvent',
                {
                    title: $('#NewTripTitle').val(),
                    start: $('#NewTripDate').val()
                },
                true // make the event "stick"
            );
    });

    $('#NewTripDate').datepicker({});
})()