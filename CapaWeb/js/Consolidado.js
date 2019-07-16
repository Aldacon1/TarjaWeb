var Consolidado = function () {
    return {
        init: function () {
            Fecha.init();
            Hora.init();
            estiloTabla();
        }
    };
}();

function estiloTabla() {
    $('#sample_2').dataTable({
        "lengthMenu": [
        [5, 15, 20, -1],
        [5, 15, 20, "All"] // change per page values here
        ],
        // set the initial value
        "pageLength": 5,
        "language": {
            "search": "Buscar: _INPUT_",
            "lengthMenu": "_MENU_ registros",
            "info": "Mostrando _END_ de _TOTAL_ registros",
            "zeroRecords": "No se encontraron registros relacionados",
            "infoEmpty": "Monstrando 0 registros",
            "infoFiltered": "(filtrados de _MAX_ registros)"
        }
    });
}


function eliminar(id) {
    var codigo = id;

    bootbox.confirm({
        size: 'small',
        message: "Esta seguro que desea eliminar el objeto seleccionado?",
        callback: function (result) { if (result) { eliminarBootbox(codigo); } else { location.href = "Desconsolidado.aspx"; } }
    });
}

function eliminarBootbox(id) {
    var corr = id;
    $.ajax({
        type: "POST",
        url: "Desconsolidado.aspx/eliminarPlanDesc",
        data: '{corr_plan: "' + corr + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }
    });

    function OnSuccess(response) {
        if (response.d == 0) {
            location.href = "Desconsolidado.aspx";
        } else {
            alerta('No puede eliminar esta Planificación. \n Asegurese que no hay tarjas asociadas.');
        }
    }
}

function modificar(id) {
    var corr = id;

    $.ajax({
        type: "POST",
        url: "Desconsolidado.aspx/modificarPlanDesc",
        data: '{corr_plan: "' + corr + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }
    });

    function OnSuccess(response) {
        var corrPlan = document.getElementById("<%=corrPlan.ClientID%>");
        var txtBl = document.getElementById("<%=txtBlMod.ClientID%>");
        var ddlpueO = document.getElementById("<%=ddlPueOrMod.ClientID%>");
        var ddlpueD = document.getElementById("<%=ddlPueDesMod.ClientID%>");
        var txtNumCont = document.getElementById("<%=txtNumContMod.ClientID%>");
        var txtSiglaCont = document.getElementById("<%=txtSiglaContMod.ClientID%>");
        var txtDvCont = document.getElementById("<%=txtDvContMod.ClientID%>");
        var ddlIso = document.getElementById("<%=ddlIsoMod.ClientID%>");
        var txtSello1 = document.getElementById("<%=txtSello1Mod.ClientID%>");
        var txtSello2 = document.getElementById("<%=txtSello2Mod.ClientID%>");
        var txtSello3 = document.getElementById("<%=txtSello3Mod.ClientID%>");
        var ddlCliente = document.getElementById("<%=ddlClienteMod.ClientID%>");

        var txtHoraI = document.getElementById("<%=txtHoraIMod.ClientID%>");
        var txtHoraT = document.getElementById("<%=txtHoraTMod.ClientID%>");
        var txtMano = document.getElementById("<%=txtManoMod.ClientID%>");
        var ddlNave = document.getElementById("<%=ddlNaveMod.ClientID%>");
        var txtViaje = document.getElementById("<%=txtViajeMod.ClientID%>");
        var ddlTerminal = document.getElementById("<%=ddlTermMod.ClientID%>");
        var ddlTarjador = document.getElementById("<%=ddlTarjadorMod.ClientID%>");

        corrPlan.value = response.d.corr_planificacion;
        txtBl.value = response.d.gls_bl;
        ddlpueO.value = response.d.cod_puerto_or;
        ddlpueD.value = response.d.cod_puerto_dest;
        txtNumCont.value = response.d.numcont;
        txtSiglaCont.value = response.d.siglacont;
        txtDvCont.value = response.d.dvCont;
        ddlIso.value = response.d.cod_iso;
        txtSello1.value = response.d.gls_sello1;
        txtSello2.value = response.d.gls_sello2;
        txtSello3.value = response.d.gls_sello3;
        ddlCliente.value = response.d.rut_cliente;

        txtHoraI.value = response.d.horaI;
        txtHoraT.value = response.d.horaT;
        txtMano.value = response.d.mano_trabajo;
        ddlNave.value = response.d.cod_nave;
        txtViaje.value = response.d.n_viaje;
        ddlTerminal.value = response.d.cod_terminal;
        ddlTarjador.value = response.d.rut_tarjador;

        $('#modificable').modal('show');

        $('#modificable').on('hidden.bs.modal', function () {
            location.href = "Desconsolidado.aspx";
        });

    }
}

function alerta(msj) {
    bootbox.confirm(msj, function (result) {
        if (result == true) {
            location.href = "Desconsolidado.aspx";
        } else {
            location.href = "Desconsolidado.aspx";
        }
    });
}

function jsDecimals(e) {

    var evt = (e) ? e : window.event;
    var key = (evt.keyCode) ? evt.keyCode : evt.which;
    if (key != null) {
        key = parseInt(key, 10);
        if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
            //Aca tenemos que reemplazar "Decimals" por "NoDecimals" si queremos que no se permitan decimales
            if (!jsIsUserFriendlyChar(key, "Decimals")) {
                return false;
            }
        }
        else {
            if (evt.shiftKey) {
                return false;
            }
        }
    }
    return true;
}

// Función para las teclas especiales
//------------------------------------------
function jsIsUserFriendlyChar(val, step) {
    // Backspace, Tab, Enter, Insert, y Delete
    if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
        return true;
    }
    // Ctrl, Alt, CapsLock, Home, End, y flechas
    if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
        return true;
    }
    if (step == "Decimals") {
        if (val == 190 || val == 110) {  //Check dot key code should be allowed
            return true;
        }
    }
    // The rest
    return false;
}