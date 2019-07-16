//********************************************************//
// Función:  ObtIniSes
// Objetivo: Realiza el inicio de sesión del usuario
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
function ObtIniSes() {
    var user = $("#txtUser").val().trim();
    var pass = $("#txtPassword").val().trim();
    var rutUser = "", dv = "";

    if (!user || !pass) {
        ShowError("¡Error!", "Debe ingresar usuario y contraseña");
        return false;
    }

    if (user.indexOf("-") > -1)
    {
        rutUser = user.split("-")[0];
        dv = user.split("-")[1];
    }
    else
    {
        ShowError("¡Error!", "Rut inválido");
        return false;
    }

    var data = { "usuario": rutUser, "contrasena": pass.toUpperCase(), "dv": dv  }

    $.ajax({
        url: $("#hdnAmbiente").val() + "/Home/ObtIniSes",
        beforeSend: function () { $('#spnLoading').show(); },
        success: function (data) {
            if (data["HasError"] === true) {
                ShowError("¡Error!", data["Message"]);
                $('#spnLoading').hide();
            } else {
                $('#FrmLogin').submit();
            }
        },
        //Siempre igual
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        type: "POST",
        datatype: "json",
        error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
    });
    return false;
}

jQuery(document).ready(function () {
    $("form input").keypress(function (e) {
        if ((e.which && e.which == 13) || (e.keyCode && e.keyCode == 13)) {
            $('#BtnLogin').click();
            return false;
        } else {
            return true;
        }
    });
});