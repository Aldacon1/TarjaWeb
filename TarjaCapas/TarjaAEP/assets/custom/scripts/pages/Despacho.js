// Función:  Constructor
// Objetivo: Inicialización de métodos para la clase
// Autor:    Franco Caamano
// Fecha:    18/07/2016
//********************************************************//
var Despacho = function () {
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
            $("#divDocsCons :input").prop('disabled', true);
            $("#divMercCons :input").prop('disabled', true);

            $("#txtPatente").keyup(function () {
                this.value = this.value.toUpperCase();
            });
            $("#txtConsignante").keyup(function () {
                this.value = this.value.toUpperCase();
            });
            $("#txtConsignatario").keyup(function () {
                this.value = this.value.toUpperCase();
            });
            $("#txtDespachante").keyup(function () {
                this.value = this.value.toUpperCase();
            });
            $("#txtMarca").keyup(function () {
                this.value = this.value.toUpperCase();
            });
            $("#txtContenido").keyup(function () {
                this.value = this.value.toUpperCase();
            });

            CargarCons();
        }
    };
}();


//********************************************************//
// Función:  Constructor
// Objetivo: Inicialización de métodos para la clase
// Autor:    Franco Caamaño Saavedra
// Fecha:    18/07/2016
//********************************************************//
function CargarCons() {
    var table = $("#tbDesp");

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
        "bSort": false //No se muestra flecha para reordenar
    });

    $.ajax({
        type: "GET",
        datatype: "json",
        url: "/Despacho/ObtLisDesp",
        success: function (dataCS) {
            if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
            else {
                oTable.fnClearTable();
                var planes = eval("(" + dataCS.aaData + ")");
                var btnDown, btnZip;
                $.each(planes, function (i) {
                    if (planes[i].estado_tarja == "Cerradas") {
                        btnDown = "<button class='btn blue download' ><i class='fa fa-cloud-download'></i></button>";
                        btnZip = "<button class='btn blue zip' ><i class='fa fa-file-zip-o'></i></button>";
                    }
                    else {
                        btnDown = "";
                        btnZip = "";
                    }
                    oTable.fnAddData([
                        "<button class='btn green edit' ><i class='fa fa-edit'></i></button>",
                        planes[i].nro_tarja,
                        planes[i].nombre_cliente,
                        planes[i].patente,
                        planes[i].fecha,
                        planes[i].terminal,
                        planes[i].estado_tarja,
                        btnDown,
                        btnZip
                    ]);
                });
            }
        },
        error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
    });

    table.on('click', '.edit', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var nroTarja = aData[1];

        $("#divPlanCons :input").prop('disabled', false);
        $("#divDocsCons :input").prop('disabled', true);
        $("#divMercCons :input").prop('disabled', true);

        var data = { "nroTarja": nroTarja }

        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Despacho/EditarPlanificacion",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing($(this), true, "");
            },
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    var planes = eval("(" + data.aaData + ")");

                    $("#txtNroTarja").val(planes[0].nro_tarja);
                    $("#txtPatente").val(planes[0].patente); //req
                    $("#ddlTerminal").val(planes[0].cod_terminal); //req
                    $("#ddlNave").val(planes[0].cod_transporte); //req
                    $("#txtVuelta").val(planes[0].n_vuelta); //req
                    $("#ddlPuertoOrigen").val(planes[0].cod_puerto_or); //req
                    $("#ddlPuertoDestino").val(planes[0].cod_puerto_dest); //req
                    $("#ddlCliente").val(planes[0].rut_cliente); //req
                    $("#txtFecha").val(""); //req
                    $("#ddlTarjador").val(planes[0].rut_tarjador);

                    $("#guardarPlanCons").css("display", "none");
                    $("#editarEncabezadoPlan").css("display", "block");

                    $("#modalConso").modal("show");
                }
            },
            complete: function () {
                ShowProcessing("#btnGuardarDespacho", false, "save");
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    });

    table.on('click', '.download', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var nro_tarja = aData[1];
        var estado = aData[10];
        window.open("CrearPdf?nro_tarja=" + nro_tarja);
    });

    table.on('click', '.zip', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var nro_tarja = aData[1];
        var estado = aData[10];
        window.open("DownloadZip?nro_tarja=" + nro_tarja);
    });
}

//********************************************************//
// Función:  guardarEncabezadoPlan()
// Objetivo: Guardar Encabezado Plan.
// Autor:    Franco Caamaño Saavedra
// Fecha:    18/07/2016
//********************************************************//
function guardarEncabezadoPlan() {
    var patente = $("#txtPatente").val().trim(); //req
    var terminal = $("#ddlTerminal").val(); //req
    var transporte = $("#ddlNave").val(); //req
    var vuelta = $("#txtVuelta").val().trim(); //req
    var puertOr = $("#ddlPuertoOrigen").val(); //req
    var puerDest = $("#ddlPuertoDestino").val(); //req
    var cliente = $("#ddlCliente").val(); //req
    var fecha = $("#txtFecha").val().trim(); //req
    var tarjador = $("#ddlTarjador").val(); //req
    var f = new Date();
    var nroTarja = f.getFullYear() + "" + f.getMonth() + "" + f.getDate() + "" + f.getHours() + "" + f.getMinutes() + "" + f.getSeconds() + "" + f.getMilliseconds();
    $("#txtNroTarja").val(nroTarja);

    var data = {
        "nroTarja": nroTarja,
        "terminal": terminal,
        "transporte": transporte,
        "vuelta": vuelta,
        "puertOr": puertOr,
        "puerDest": puerDest,
        "cliente": cliente,
        "patente": patente,
        "fecha": fecha,
        "tarjador": tarjador
    }

    if (terminal.length <= 0) ShowError("¡Error¡", "Debe ingresar el terminal");
    else if (transporte.length <= 0) ShowError("¡Error¡", "Debe ingresar el transporte");
    else if (vuelta.length <= 0) ShowError("¡Error¡", "Debe ingresar la vuelta");
    else if (puertOr.length <= 0) ShowError("¡Error¡", "Debe ingresar el puerto origen");
    else if (puerDest.length <= 0) ShowError("¡Error¡", "Debe ingresar el puerto de destino");
    else if (cliente.length <= 0) ShowError("¡Error¡", "Debe ingresar el cliente");
    else if (patente.length <= 0) ShowError("¡Error¡", "Debe ingresar la patente");
    else if (fecha.length <= 0) ShowError("¡Error¡", "Debe ingresar la fecha");
    else if (tarjador.length <= 0) ShowError("¡Error¡", "Debe ingresar el tarjador");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Despacho/GuardarPlanDesp",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#guardarPlanCons", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    $("#divPlanCons :input").prop('disabled', true);
                    $("#divDocsCons :input").prop('disabled', false);

                    $("#guardarPlanCons").prop('disabled', true);

                    cargarDocsCons();
                }
            },
            complete: function () {
                ShowProcessing("#guardarPlanCons", false, "save");
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}

//********************************************************//
// Función:  cargarDocsCons()
// Objetivo: Cargar tabla de Documentos del Consolidado
// Autor:    Franco Caamaño Saavedra
// Fecha:    18/07/2016
//********************************************************//
function cargarDocsCons() {
    var table = $("#tbDocsConso");

    var nroTarja = $("#txtNroTarja").val().trim();

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
        "bSort": false //No se muestra flecha para reordenar
    });

    var data = {
        "nroTarja": nroTarja
    }

    $.ajax({
        contentType: "application/json; charset=utf-8",
        type: "POST",
        datatype: "json",
        url: "/Despacho/ObtLisDocDesp",
        data: JSON.stringify(data),
        success: function (dataCS) {
            if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
            else {
                oTable.fnClearTable();
                var planes = eval("(" + dataCS.aaData + ")");
                $.each(planes, function (i) {
                    oTable.fnAddData([
                        planes[i].nombre,
                        planes[i].nro_documento,
                        planes[i].dres,
                        planes[i].gls_consignante,
                        planes[i].gls_consignatario,
                        planes[i].gls_despachante,
                        "<button class='btn red deleteDocs'><i class='fa fa-trash-o'></i></button>"
                    ]);
                });
            }
        },
        error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
    });

    table.on('click', '.deleteDocs', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var nroDoc = aData[1];
        var nroTarja = $("#txtNroTarja").val().trim();

        var tieneError = tieneMerc(nroDoc, nroTarja);

        if (tieneError == 1) {

            ShowError("¡Error!", "El documento tiene mercancias asociadas, por lo que no se puede eliminar.");

        } else {

            var data = {
                "nroDoc": nroDoc,
                "nroTarja": nroTarja
            }


            $.ajax({
                contentType: "application/json; charset=utf-8",
                type: "POST",
                datatype: "json",
                url: "/Despacho/EliminarDoc",
                data: JSON.stringify(data),
                beforeSend: function () {
                    ShowProcessing($(this), true, "");
                },
                success: function (data) {
                    if (data.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
                    else {
                        ShowSuccess("¡Hecho!", data["Message"]);
                        cargarDocsCons();
                    }
                },
                complete: function () {
                    ShowProcessing("#btnGuardarDespacho", false, "save");
                },
                error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
            });
        }
    });
}

//********************************************************//
// Función:  guardarDocCons()
// Objetivo: Guardar documento de consolidado
// Autor:    Franco Caamaño Saavedra
// Fecha:    18/07/2016
//********************************************************//
function guardarDocCons() {

    var nroTarja = $("#txtNroTarja").val().trim();
    var tipoDoc = $("#ddlTipoDocumento").val().trim();
    var nroDoc = $("#txtNroDoc").val().trim();
    var dres = $("#txtDres").val().trim();
    var consignante = $("#txtConsignante").val().trim();
    var consignatario = $("#txtConsignatario").val().trim();
    var despachante = $("#txtDespachante").val().trim();

    var data = {
        "nroTarja": nroTarja,
        "nroDoc": nroDoc,
        "tipoDoc": tipoDoc,
        "dres": dres,
        "consignante": consignante,
        "consignatario": consignatario,
        "despachante": despachante
    }

    if (nroDoc.length <= 0) ShowError("¡Error¡", "Debe ingresar el numero de documento");
    else if (tipoDoc.length <= 0) ShowError("¡Error¡", "Debe seleccionar el tipo de documento");
    else if (dres.length <= 0) ShowError("¡Error¡", "Debe ingresar el dres");
    else if (consignante.length <= 0) ShowError("¡Error¡", "Debe ingresar el consignante");
    else if (consignatario.length <= 0) ShowError("¡Error¡", "Debe ingresar el consignatario");
    else if (despachante.length <= 0) ShowError("¡Error¡", "Debe ingresar el despachante");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Despacho/GuardarDocDesp",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#guardarDocCons", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (dataCS) {
                if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    $("#divDocsCons :input").prop('disabled', true);
                    $("#divMercCons :input").prop('disabled', false)
                    $("#guardarDocCons").prop('disabled', true);

                    cargarDocsCons();
                    cargarMercCons();
                }
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}

//********************************************************//
// Función:  guardarMercCons()
// Objetivo: Guardar mercancias de consolidado
// Autor:    Franco Caamaño Saavedra
// Fecha:    18/07/2016
//********************************************************//
function guardarMercCons() {

    var nroTarja = $("#txtNroTarja").val().trim();
    var nroDoc = $("#txtNroDoc").val().trim();
    var f = new Date();
    var codMercancia = f.getDate() + "" + f.getMonth() + "" + f.getFullYear() + "" + f.getHours() + "" + f.getMinutes() + "" + f.getSeconds() + "" + f.getMilliseconds();
    var marca = $("#txtMarca").val().trim();
    var contenido = $("#txtContenido").val().trim();
    var bultoPrin = $("#ddlBultoPrin").val().trim();
    var bultoSec = $("#ddlBultoSec").val().trim();
    var alto = $("#txtAlto").val().trim();
    var largo = $("#txtLargo").val().trim();
    var ancho = $("#txtAncho").val().trim();
    var cantidad = $("#txtCantidad").val().trim();
    var peso = $("#txtPeso").val().trim();


    var data = {
        "nroTarja": nroTarja,
        "nroDoc": nroDoc,
        "codMercancia": codMercancia,
        "marca": marca,
        "contenido": contenido,
        "contenedor": contenido,
        "bultoPrin": bultoPrin,
        "bultoSec": bultoSec,
        "alto": alto,
        "largo": largo,
        "ancho": ancho,
        "cantidad": cantidad,
        "peso": peso
    }

    if (marca.length <= 0) ShowError("¡Error¡", "Debe ingresar la marca");
    else if (contenido.length <= 0) ShowError("¡Error¡", "Debe seleccionar el contenido");
    else if (bultoPrin.length <= 0) ShowError("¡Error¡", "Debe seleccionar el bulto principal");
    else if (bultoSec.length <= 0) ShowError("¡Error¡", "Debe seleccionar el bulto secundario");
    else if (alto.length <= 0) ShowError("¡Error¡", "Debe ingresar el alto");
    else if (largo.length <= 0) ShowError("¡Error¡", "Debe ingresar el largo");
    else if (ancho.length <= 0) ShowError("¡Error¡", "Debe ingresar el ancho");
    else if (cantidad.length <= 0) ShowError("¡Error¡", "Debe ingresar la cantidad");
    else if (peso.length <= 0) ShowError("¡Error¡", "Debe ingresar el peso");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Despacho/GuardarMercDesp",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#guardarMercCons", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (dataCS) {
                if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    $("#divMercCons :input").prop('disabled', true);
                    $("#guardarMercCons").prop('disabled', true);

                    cargarMercCons();
                }
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}

//********************************************************//
// Función:  cargarMercCons()
// Objetivo: Cargar tabla de Mercancias del Consolidado
// Autor:    Franco Caamaño Saavedra
// Fecha:    18/07/2016
//********************************************************//
function cargarMercCons() {
    var table = $("#tbMercsConso");

    var nroTarja = $("#txtNroTarja").val().trim();
    var nroDoc = $("#txtNroDoc").val().trim();

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

    var data = {
        "nroTarja": nroTarja,
        "nroDoc": nroDoc
    }

    $.ajax({
        contentType: "application/json; charset=utf-8",
        type: "POST",
        datatype: "json",
        url: "/Despacho/ObtLisMercDesp",
        data: JSON.stringify(data),
        success: function (dataCS) {
            if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
            else {
                oTable.fnClearTable();
                var planes = eval("(" + dataCS.aaData + ")");
                $.each(planes, function (i) {
                    oTable.fnAddData([
                        planes[i].cod_mercancia,
                        planes[i].gls_marca,
                        planes[i].gls_contenido,
                        planes[i].f_peso,
                        planes[i].f_alto,
                        planes[i].f_largo,
                        planes[i].f_ancho,
                        planes[i].n_cantidad,
                        "<button class='btn red deleteMerc'><i class='fa fa-trash-o'></i></button>"
                    ]);
                });
            }
        },
        error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
    });

    table.on('click', '.deleteMerc', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var codMercancia = aData[0];

        var data = {
            "codMercancia": codMercancia
        }


        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Despacho/EliminarMercDesp",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing($(this), true, "");
            },
            success: function (data) {
                if (data.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    cargarMercCons();
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
// Función:  finalizarPlanCons()
// Objetivo: Cierra modal y carga tabla
// Autor:    Franco Caamaño Saavedra
// Fecha:    18/07/2016
//********************************************************//
function finalizarPlanCons() {
    CargarCons();
    $("#modalConso").modal("hide");
}

//********************************************************//
// Función:  agregarDocDesp()
// Objetivo: Habilita form para agregar nuevo doc
// Autor:    Franco Caamaño Saavedra
// Fecha:    18/07/2016
//********************************************************//
function agregarDocDesp() {
    $("#txtNroDoc").val("");
    $("#ddlTipoDocumento").val("");
    $("#txtNroDoc").val("");
    $("#txtDres").val("");
    $("#txtConsignante").val("");
    $("#txtConsignatario").val("");
    $("#txtDespachante").val("");
    $("#txtMarca").val("");
    $("#txtContenido").val("");
    $("#ddlBultoPrin").val("");
    $("#ddlBultoSec").val("");
    $("#txtAlto").val("");
    $("#txtLargo").val("");
    $("#txtAncho").val("");
    $("#txtCantidad").val("");
    $("#txtPeso").val("");

    $("#divDocsCons :input").prop('disabled', false);
}

//********************************************************//
// Función:  agregarMercCons()
// Objetivo: Habilita form para agregar nueva mercancia
// Autor:    Franco Caamaño Saavedra
// Fecha:    18/07/2016
//********************************************************//
function agregarMercCons() {
    $("#txtMarca").val("");
    $("#txtContenido").val("");
    $("#ddlBultoPrin").val("");
    $("#ddlBultoSec").val("");
    $("#txtAlto").val("");
    $("#txtLargo").val("");
    $("#txtAncho").val("");
    $("#txtCantidad").val("");
    $("#txtPeso").val("");

    $("#divMercCons :input").prop('disabled', false);
}

//********************************************************//
// Función:  tieneMerc()
// Objetivo: valida existencia de mercancias por documento
// Autor:    Franco Caamaño Saavedra
// Fecha:    18/07/2016
//********************************************************//
function tieneMerc(nroDoc, nroTarja) {
    var data = {
        "nroDoc": nroDoc,
        "nroTarja": nroTarja
    }

    var tiene = 1;

    $.ajax({
        async: false,
        contentType: "application/json; charset=utf-8",
        type: "POST",
        datatype: "json",
        url: "/Despacho/ObtLisMercDesp",
        data: JSON.stringify(data),
        success: function (dataCS) {
            if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
            else {
                var planes = eval("(" + dataCS.aaData + ")");
                if (planes.length == 0) {
                    tiene = 0;
                }
                else {
                    tiene = 1;
                }
            }
        },
        error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
    });

    return tiene;
}

//********************************************************//
// Función:  tieneMerc()
// Objetivo: valida existencia de mercancias por documento
// Autor:    Franco Caamaño Saavedra
// Fecha:    18/07/2016
//********************************************************//
function editarEncabezadoPlan() {
    var patente = $("#txtPatente").val().trim(); //req
    var terminal = $("#ddlTerminal").val(); //req
    var transporte = $("#ddlNave").val(); //req
    var vuelta = $("#txtVuelta").val().trim(); //req
    var puertOr = $("#ddlPuertoOrigen").val(); //req
    var puerDest = $("#ddlPuertoDestino").val(); //req
    var cliente = $("#ddlCliente").val(); //req
    var fecha = $("#txtFecha").val().trim(); //req
    var tarjador = $("#ddlTarjador").val(); //req
    var nroTarja = $("#txtNroTarja").val().trim();

    var data = {
        "nroTarja": nroTarja,
        "terminal": terminal,
        "transporte": transporte,
        "vuelta": vuelta,
        "puertOr": puertOr,
        "puerDest": puerDest,
        "cliente": cliente,
        "patente": patente,
        "fecha": fecha,
        "tarjador": tarjador
    }

    if (terminal.length <= 0) ShowError("¡Error¡", "Debe ingresar la reserva");
    else if (transporte.length <= 0) ShowError("¡Error¡", "Debe ingresar el terminal");
    else if (vuelta.length <= 0) ShowError("¡Error¡", "Debe ingresar la nave");
    else if (puertOr.length <= 0) ShowError("¡Error¡", "Debe ingresar el viaje");
    else if (puerDest.length <= 0) ShowError("¡Error¡", "Debe ingresar el puerto de origen");
    else if (cliente.length <= 0) ShowError("¡Error¡", "Debe ingresar el puerto de destino");
    else if (patente.length <= 0) ShowError("¡Error¡", "Debe ingresar el cliente");
    else if (fecha.length <= 0) ShowError("¡Error¡", "Debe ingresar el contenedor");
    else if (tarjador.length <= 0) ShowError("¡Error¡", "Debe ingresar el codigo iso");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Despacho/GuardarPlanEditDesp",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#editarEncabezadoPlan", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    $("#divPlanCons :input").prop('disabled', true);
                    $("#divDocsCons :input").prop('disabled', false);

                    $("#guardarPlanCons").prop('disabled', true);

                    cargarDocsCons();
                }
            },
            complete: function () {
                ShowProcessing("#editarEncabezadoPlan", false, "save");
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}

function limpiarForm() {
    $("#txtPatente").val(""); //req
    $("#ddlTerminal").val(""); //req
    $("#ddlNave").val(""); //req
    $("#txtVuelta").val(""); //req
    $("#ddlPuertoOrigen").val(""); //req
    $("#ddlPuertoDestino").val(""); //req
    $("#ddlCliente").val(""); //req
    $("#txtFecha").val(""); //req
    $("#ddlTarjador").val(""); //req
    $("#txtNroDoc").val("");
    $("#ddlTipoDocumento").val("");
    $("#txtNroDoc").val("");
    $("#txtDres").val("");
    $("#txtConsignante").val("");
    $("#txtConsignatario").val("");
    $("#txtDespachante").val("");
    $("#txtMarca").val("");
    $("#txtContenido").val("");
    $("#ddlBultoPrin").val("");
    $("#ddlBultoSec").val("");
    $("#txtAlto").val("");
    $("#txtLargo").val("");
    $("#txtAncho").val("");
    $("#txtCantidad").val("");
    $("#txtPeso").val("");
    $("#txtMarca").val("");
    $("#txtContenido").val("");
    $("#ddlBultoPrin").val("");
    $("#ddlBultoSec").val("");
    $("#txtAlto").val("");
    $("#txtLargo").val("");
    $("#txtAncho").val("");
    $("#txtCantidad").val("");
    $("#txtPeso").val("");
}