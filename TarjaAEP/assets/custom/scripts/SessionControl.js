//********************************************************//
// Función:  Constructor
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
var SessionControl = function () {
    var handleCleanSession = function () {
        $(window).on('beforeunload', function() {
            $.ajax({
                type: 'POST',
                url: '/Session/CleanSession'
            });
        });
    }

    return {
        //main function to initiate the module
        init: function () {
            handleCleanSession();
        }
    };
}();

//********************************************************//
// Función:  SwitchLanguage
// Objetivo: Realiza el cambio del lenguaje
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
function SwitchLanguage(culture) {
    var datos = {
        "culture": culture
    }

    $.ajax({
        url: '/Session/SwitchLanguage',
        data: JSON.stringify(datos),
        contentType: "application/json; charset=utf-8",
        success: function () {
            document.location.reload();
        },
        type: "POST",
        datatype: "json"
    });
}