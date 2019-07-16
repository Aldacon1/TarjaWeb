var Hora = function () {

    var handleTimePickers = function () {

        if (jQuery().timepicker) {
            $('.timepicker-tarja').timepicker({
                timeFormat: 'HH:mm',
                autoclose: true
            });
        }
    }

    return {
        init: function () {

            handleTimePickers();

        }
    };

} ();