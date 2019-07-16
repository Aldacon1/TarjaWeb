// Función:  Constructor
// Objetivo: Inicialización de métodos para la clase
// Autor:    Franco Caamano
// Fecha:    11/04/2016
//********************************************************//
var Desconsolidado = function () {
    return {
        init: function () {
            $('.date-picker').datepicker({
                rtl: Metronic.isRTL(),
                orientation: "left",
                autoclose: true,
                language: 'es',
                format: 'dd/mm/yyyy'
            });
            $('.timepicker-tarja').timepicker({
                timeFormat: 'HH:mm',
                autoclose: true,
                showMeridian: false
            });
            $("#txtContenedor").inputmask("AAAA999999-9");
            $("#txtContenedorEdit").inputmask("AAAA999999-9");
            $("#txtBL").keyup(function () {
                this.value = this.value.toUpperCase();
            });
            $("#txtBLEdit").keyup(function () {
                this.value = this.value.toUpperCase();
            });
            $("#txtMddt").keyup(function () {
                this.value = this.value.toUpperCase();
            });
            $("#txtMddtEdit").keyup(function () {
                this.value = this.value.toUpperCase();
            });
            CargarDesc();

            $('#modalDescVideo').on('hidden.bs.modal', function () {
                $("#linksDiv").empty();
            });
        }
    };
}();


//********************************************************//
// Función:  Constructor
// Objetivo: Inicialización de métodos para la clase
// Autor:    Franco Caamaño Saavedra
// Fecha:    11/04/2016
//********************************************************//
function CargarDesc() {
    var table = $("#tbDesco");

    var oTable = table.dataTable({
        destroy: true,
        bProcessing: false,
        "lengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
        ],
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "<i class='fa fa-angle-right'></i>",
                "sPrevious": "<i class='fa fa-angle-left'></i>"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        "pagingType": "simple_numbers", //Se muestra '<' '>' y Números
        'iDisplayLength': 5, //10 Registros por página
        'bLengthChange': true, //No se puede cambiar la cantidad de registros por página
        "bInfo": true, //No se muestra mensaje de información de registros
        "bFilter": true, //No se muestra cuadro de búsqueda
        "bSort": false, //No se muestra flecha para reordenar
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": true
            }
        ]
    });

    $.ajax({
        type: "GET",
        datatype: "json",
        url: "/Desconsolidado/ObtLisDesc",
        success: function (dataCS) {
            if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
            else {
                oTable.fnClearTable();
                var planes = eval("(" + dataCS.aaData + ")");
                var btnDown, btnZip, btnVideo;
                $.each(planes, function (i) {
                    if (planes[i].estado == "Cerradas") {
                        btnDown = "<button class='btn blue download' ><i class='fa fa-cloud-download'></i></button>";
                        btnZip = "<button class='btn blue zip' ><i class='fa fa-file-zip-o'></i></button>";
                        btnVideo = "<button class='btn blue video' ><i class='fa fa-file-video-o'></i></button>";
                    }
                    else {
                        btnDown = "";
                        btnZip = "";
                        btnVideo = "";
                    }
                    oTable.fnAddData([
                        planes[i].corr_planificacion,
                        "<button class='btn red delete'><i class='fa fa-trash-o'></i></button>",
                        "<button class='btn green edit' ><i class='fa fa-edit'></i></button>",
                        planes[i].gls_bl,
                        planes[i].CLIENTE,
                        planes[i].NAVE,
                        planes[i].CONTENEDOR,
                        planes[i].FECHA,
                        planes[i].terminal,
                        planes[i].desbloqueo,
                        planes[i].estado,
                        btnDown,
                        btnZip,
                        btnVideo
                    ]);
                });
            }
        },
        error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
    });



    table.on('click', '.delete', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var corr_planificacion = aData[0];
        var estado = aData[10];
        var data = { "corr_planificacion": corr_planificacion }

        if (estado == 'Programada') {
            $.ajax({
                contentType: "application/json; charset=utf-8",
                type: "POST",
                datatype: "json",
                url: "/Desconsolidado/EliminarPlanificacion",
                data: JSON.stringify(data),
                beforeSend: function () {
                    ShowProcessing($(this), true, "");
                },
                success: function (data) {
                    if (data.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
                    else {
                        ShowSuccess("¡Hecho!", data["Message"]);
                        GoTop();
                        CargarDesc();
                    }
                },
                complete: function () {
                    ShowProcessing("#btnGuardarDespacho", false, "save");
                },
                error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
            });
        } else {
            ShowError("¡Error!", "La tarja no puede ser eliminada, si ya ha sido iniciada y necesita eliminar. Contacctese con el admin del sistema.");
        }
    });

    table.on('click', '.edit', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var corr_planificacion = aData[0];
        var estado = aData[10];
        var data = { "corr_planificacion": corr_planificacion }

        if (estado == 'Programada') {
            $.ajax({
                contentType: "application/json; charset=utf-8",
                type: "POST",
                datatype: "json",
                url: "/Desconsolidado/EditarPlanificacion",
                data: JSON.stringify(data),
                beforeSend: function () {
                    ShowProcessing($(this), true, "");
                },
                success: function (data) {
                    if (data.HasError === true) ShowError("¡Error!", data.Message);
                    else {
                        var planes = eval("(" + data.aaData + ")");

                        $("#txtBLEdit").val(planes.bl);
                        $("#txtMddtEdit").val(planes.mddt);
                        $("#ddlTerminalEdit").val(planes.cod_agencia); //req
                        $("#ddlNaveEdit").val(planes.cod_nave); //req
                        $("#txtViajeEdit").val(planes.cod_viaje); //req
                        $("#ddlPuertoOrigenEdit").val(planes.pue_codO); //req
                        $("#ddlPuertoDestinoEdit").val(planes.pue_codD); //req
                        $("#ddlClienteEdit").val(planes.rut_cliente); //req
                        $("#txtContenedorEdit").val(planes.cod_contenedor); //req
                        $("#ddlIsoEdit").val(planes.cod_iso); //req
                        $("#txtSello1Edit").val(planes.sello1); //req
                        $("#ddlTarjadorEdit").val(planes.rut_tarjador); //req
                        $("#corr_plan").val(planes.cod_manifiesto);
                        $("#corr_plan").prop('readonly', true);

                        $("#modalDescoEdit").modal("show");
                    }
                },
                complete: function () {
                    ShowProcessing("#btnGuardarDespacho", false, "save");
                },
                error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
            });
        } else {
            ShowError("¡Error!", "La tarja no puede ser eliminada, si ya ha sido iniciada y necesita eliminar. Contacctese con el admin del sistema.");
        }
    });

    table.on('click', '.download', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var corr_planificacion = aData[0];
        var estado = aData[10];
        window.open("CrearPdf?corr_planificacion=" + corr_planificacion);
    });

    table.on('click', '.zip', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var corr_planificacion = aData[0];
        var estado = aData[10];
        window.open("DowndZip?corr_planificacion=" + corr_planificacion);
    });

    table.on('click', '.video', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var contenedor = aData[6];

        var cnt = SplitContenedorTarja(contenedor);
        if (!cnt.sigla) return false;

        var sigcnt = cnt["sigla"];
        var numcnt = cnt["numero"];
        var dvcnt = cnt["digito"];

        var strContenedor = sigcnt.concat(' - ', numcnt, ' - ', dvcnt);

        var data = { "contenedor": strContenedor }

        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Desconsolidado/obtLinksVideo",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing($(this), true, "");
            },
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    var links = eval("(" + data.aaData + ")");

                    $.each(links, function (i) {
                        $("#linksDiv").append(jQuery('<a>')
                            .attr('href', 'http://aplicaciones.aep.cl/Videos/' + links[i].sGls_videos)
                            .attr('target', '_blank')
                            .text(links[i].sGls_videos));
                        $("#linksDiv").append(jQuery('<br>'));
                    });
                    

                    $("#modalDescVideo").modal("show");
                }
            },
            complete: function () {
                ShowProcessing("#btnGuardarDespacho", false, "save");
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    });
}

//********************************************************//
// Función:  guardarPlan()
// Objetivo: Guardar Planificacion de desconsolidado
// Autor:    Franco Caamaño Saavedra
// Fecha:    24/06/2016
//********************************************************//
function guardarPlan() {
    var bl = $("#txtBL").val().trim(); //req
    var mddt = $("#txtMddt").val().trim();
    var terminal = $("#ddlTerminal").val(); //req
    var nave = $("#ddlNave").val(); //req
    var viaje = $("#txtViaje").val().trim(); //req
    var puertOr = $("#ddlPuertoOrigen").val(); //req
    var puerDest = $("#ddlPuertoDestino").val(); //req
    var cliente = $("#ddlCliente").val(); //req
    var valCnt = SplitContenedor($("#txtContenedor").val().trim()); //req
    var contenedor = valCnt["sigla"] + valCnt["numero"] + valCnt["digito"]; //req
    var iso = $("#ddlIso").val(); //req
    var sello = $("#txtSello1").val().trim(); //req
    var fecha = $("#txtFecha").val().trim(); //req
    var hInicio = $("#txtHoraI").val().trim(); //req
    var hTermino = $("#txtHoraT").val().trim(); //req
    var tarjador = $("#ddlTarjador").val(); //req
    var f = new Date();
    var manifiesto = f.getFullYear() + "" + f.getMonth() + 1 + "" + f.getDate() + "" + f.getHours() + "" + f.getMinutes() + "" + f.getSeconds() + "-" + f.getMilliseconds() + "" + Math.floor((Math.random() * 1000) + 1);

    var data = {
        "manifiesto": manifiesto,
        "bl": bl,
        "mddt": mddt,
        "terminal": terminal,
        "contenedor": contenedor,
        "nave": nave,
        "viaje": viaje,
        "puertOr": puertOr,
        "puerDest": puerDest,
        "cliente": cliente,
        "iso": iso,
        "sello": sello,
        "fecha": fecha,
        "hInicio": hInicio,
        "hTermino": hTermino,
        "tarjador": tarjador
    }

    if (bl.length <= 0) ShowError("¡Error¡", "Debe ingresar el BL");
    else if (terminal.length <= 0) ShowError("¡Error¡", "Debe ingresar el terminal");
    else if (nave.length <= 0) ShowError("¡Error¡", "Debe ingresar la nave");
    else if (viaje.length <= 0) ShowError("¡Error¡", "Debe ingresar el viaje");
    else if (puertOr.length <= 0) ShowError("¡Error¡", "Debe ingresar el puerto de origen");
    else if (puerDest.length <= 0) ShowError("¡Error¡", "Debe ingresar el puerto de destino");
    else if (cliente.length <= 0) ShowError("¡Error¡", "Debe ingresar el cliente");
    else if (contenedor.length <= 0) ShowError("¡Error¡", "Debe ingresar el contenedor");
    else if (iso.length <= 0) ShowError("¡Error¡", "Debe ingresar el codigo iso");
    else if (sello.length <= 0) ShowError("¡Error¡", "Debe ingresar el sello");
    else if (fecha.length <= 0) ShowError("¡Error¡", "Debe ingresar la fecha");
    else if (hInicio.length <= 0) ShowError("¡Error¡", "Debe ingresar la hora de inicio");
    else if (hTermino.length <= 0) ShowError("¡Error¡", "Debe ingresar la hora de termino");
    else if (tarjador.length <= 0) ShowError("¡Error¡", "Debe ingresar el tarjador");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Desconsolidado/GuardarPlanDesc",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#btnGuardaPlanDesc", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    $("#txtBL").val("");
                    $("#txtMddt").val("");
                    $("#ddlTerminal").val(""); //req
                    $("#ddlNave").val(""); //req
                    $("#txtViaje").val(""); //req
                    $("#ddlPuertoOrigen").val(""); //req
                    $("#ddlPuertoDestino").val(""); //req
                    $("#ddlCliente").val(""); //req
                    $("#txtContenedor").val(""); //req
                    $("#ddlIso").val(""); //req
                    $("#txtSello1").val(""); //req
                    $("#txtFecha").val(""); //req
                    $("#txtHoraI").val(""); //req
                    $("#txtHoraT").val(""); //req
                    $("#ddlTarjador").val(""); //req

                    CargarDesc();

                    $("#modalDesco").modal("hide");
                }
            },
            complete: function () {
                ShowProcessing("#btnGuardarDespacho", false, "save");
                //ActivarDesactivarBoton("#btnGuardarDespacho", true);
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}

//********************************************************//
// Función:  guardarPlanEdit()
// Objetivo: Guardar Planificacion de desconsolidado
// Autor:    Franco Caamaño Saavedra
// Fecha:    07/07/2016
//********************************************************//
function guardarPlanEdit() {
    var bl = $("#txtBLEdit").val().trim(); //req
    var mddt = $("#txtMddtEdit").val().trim();
    var terminal = $("#ddlTerminalEdit").val(); //req
    var nave = $("#ddlNaveEdit").val(); //req
    var viaje = $("#txtViajeEdit").val().trim(); //req
    var puertOr = $("#ddlPuertoOrigenEdit").val(); //req
    var puerDest = $("#ddlPuertoDestinoEdit").val(); //req
    var cliente = $("#ddlClienteEdit").val(); //req
    var valCnt = SplitContenedor($("#txtContenedorEdit").val().trim()); //req
    var contenedor = valCnt["sigla"] + valCnt["numero"] + valCnt["digito"]; //req
    var iso = $("#ddlIsoEdit").val(); //req
    var sello = $("#txtSello1Edit").val().trim(); //req
    var fecha = $("#txtFechaEdit").val().trim(); //req
    var hInicio = $("#txtHoraIEdit").val().trim(); //req
    var hTermino = $("#txtHoraTEdit").val().trim(); //req
    var tarjador = $("#ddlTarjadorEdit").val(); //req
    var manifiesto = $("#corr_plan").val().trim();

    var data = {
        "manifiesto": manifiesto,
        "bl": bl,
        "mddt": mddt,
        "terminal": terminal,
        "contenedor": contenedor,
        "nave": nave,
        "viaje": viaje,
        "puertOr": puertOr,
        "puerDest": puerDest,
        "cliente": cliente,
        "iso": iso,
        "sello": sello,
        "fecha": fecha,
        "hInicio": hInicio,
        "hTermino": hTermino,
        "tarjador": tarjador
    }

    if (bl.length <= 0) ShowError("¡Error¡", "Debe ingresar el BL");
    else if (terminal.length <= 0) ShowError("¡Error¡", "Debe ingresar el terminal");
    else if (nave.length <= 0) ShowError("¡Error¡", "Debe ingresar la nave");
    else if (viaje.length <= 0) ShowError("¡Error¡", "Debe ingresar el viaje");
    else if (puertOr.length <= 0) ShowError("¡Error¡", "Debe ingresar el puerto de origen");
    else if (puerDest.length <= 0) ShowError("¡Error¡", "Debe ingresar el puerto de destino");
    else if (cliente.length <= 0) ShowError("¡Error¡", "Debe ingresar el cliente");
    else if (contenedor.length <= 0) ShowError("¡Error¡", "Debe ingresar el contenedor");
    else if (iso.length <= 0) ShowError("¡Error¡", "Debe ingresar el codigo iso");
    else if (sello.length <= 0) ShowError("¡Error¡", "Debe ingresar el sello");
    else if (fecha.length <= 0) ShowError("¡Error¡", "Debe ingresar la fecha");
    else if (hInicio.length <= 0) ShowError("¡Error¡", "Debe ingresar la hora de inicio");
    else if (hTermino.length <= 0) ShowError("¡Error¡", "Debe ingresar la hora de termino");
    else if (tarjador.length <= 0) ShowError("¡Error¡", "Debe ingresar el tarjador");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Desconsolidado/GuardarPlanEditDesc",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#btnGuardaPlanDesc", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    $("#txtBLEdit").val("");
                    $("#txtMddtEdit").val("");
                    $("#ddlTerminalEdit").val(""); //req
                    $("#ddlNaveEdit").val(""); //req
                    $("#txtViajeEdit").val(""); //req
                    $("#ddlPuertoOrigenEdit").val(""); //req
                    $("#ddlPuertoDestinoEdit").val(""); //req
                    $("#ddlClienteEdit").val(""); //req
                    $("#txtContenedorEdit").val(""); //req
                    $("#ddlIsoEdit").val(""); //req
                    $("#txtSello1Edit").val(""); //req
                    $("#txtFechaEdit").val(""); //req
                    $("#txtHoraIEdit").val(""); //req
                    $("#txtHoraTEdit").val(""); //req
                    $("#ddlTarjadorEdit").val(""); //req
                    $("#corr_plan").val(""); //req

                    CargarDesc();

                    $("#modalDescoEdit").modal("hide");
                }
            },
            complete: function () {
                ShowProcessing("#btnGuardarDespacho", false, "save");
                //ActivarDesactivarBoton("#btnGuardarDespacho", true);
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}