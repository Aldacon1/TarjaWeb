
//********************************************************//
// Función:  ShowProcessing
// Objetivo: Muestra un ícono de procesos mientras se ejecuta
//           código servidor
// Autor:    Diego Hernandez
// Fecha:    08/05/2015
//********************************************************//
function ShowProcessing(elemento, estaCargando,FAicono) {
    if (estaCargando) $(elemento).find("i").removeClass().addClass("fa fa-spinner fa-spin");
    else $(elemento).find("i").removeClass().addClass("fa fa-" + FAicono);
}

//********************************************************//
// Función:  ShowInfo
// Objetivo: Genera una alerta de información
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
function ShowInfo(title, msg) {
    toastr.options = {
        closeButton: 'true',
        debug: 'false',
        positionClass: 'toast-top-right',
        showDuration: '1000',
        hideDuration: '1000',
        timeOut: '5000',
        showEasing: 'swing',
        hideEasing: 'linear',
        showMethod: 'fadeIn',
        hideMethod: 'fadeOut'
    };

    toastr['info'](msg, title);
}

//********************************************************//
// Función:  ShowInfo
// Objetivo: Genera una alerta de error
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
function ShowError(title, msg) {
    toastr.options = {
        closeButton: 'true',
        debug: 'false',
        positionClass: 'toast-top-right',
        showDuration: '1000',
        hideDuration: '1000',
        timeOut: '5000',
        showEasing: 'swing',
        hideEasing: 'linear',
        showMethod: 'fadeIn',
        hideMethod: 'fadeOut'
    };

    toastr['error'](msg, title);
}

//********************************************************//
// Función:  ShowInfo
// Objetivo: Genera una alerta de éxito
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
function ShowSuccess(title, msg) {
    toastr.options = {
        closeButton: 'true',
        debug: 'false',
        positionClass: 'toast-top-right',
        showDuration: '1000',
        hideDuration: '1000',
        timeOut: '5000',
        showEasing: 'swing',
        hideEasing: 'linear',
        showMethod: 'fadeIn',
        hideMethod: 'fadeOut'
    };

    toastr['success'](msg, title);
}

function ShowWarning(title, msg) {
    toastr.options = {
        closeButton: 'true',
        debug: 'false',
        positionClass: 'toast-top-right',
        showDuration: '1000',
        hideDuration: '1000',
        timeOut: '5000',
        showEasing: 'swing',
        hideEasing: 'linear',
        showMethod: 'fadeIn',
        hideMethod: 'fadeOut'
    };

    toastr['warning'](msg, title);
}

