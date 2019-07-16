//********************************************************//
// Función:  Constructor
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
var Geocoding = function () {
    var mapGeocoding = function () {
        var map = new GMaps({
            div: '#gmap_geocoding',
            lat: -12.043333,
            lng: -77.028333
        });

        var text = $.trim($('#Direccion').val());
        //alert($.trim($('#Direccion').val()));
        GMaps.geocode({
            address: text,
            callback: function (results, status) {
                //alert(status);
                if (status === 'OK') {
                    var latlng = results[0].geometry.location;
                    map.setCenter(latlng.lat(), latlng.lng());
                    map.addMarker({
                        lat: latlng.lat(),
                        lng: latlng.lng()
                    });
                }
            }
        });
    }

    return {
        init: function () {
            mapGeocoding();
        }
    };
}();