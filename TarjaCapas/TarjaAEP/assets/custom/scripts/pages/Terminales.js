var Terminales = function () {
    return {
        init: function () {
            cargarTerminales();
            $("#txtDescripcion").keyup(function () {
                this.value = this.value.toUpperCase();
            });

            $('#modalTerminales').on('hidden.bs.modal', function () {
                $("#txtCodigo").val("");
                $("#txtDescripcion").val("");
                $("#txtCodigo").prop('disabled', false);

                $("#guardarTerminal").css("display", "inline");
                $("#editarTerminal").css("display", "none");
                cargarTerminales();
            })
        }
    };
}();

function cargarTerminales() {
    var table = $("#tbTerminales");

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
        url: "/Mantenedores/obtTerminales",
        success: function (dataCS) {
            if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
            else {
                oTable.fnClearTable();
                var terminales = eval("(" + dataCS.aaData + ")");
                $.each(terminales, function (i) {
                    oTable.fnAddData([
                        "<button class='btn green edit' ><i class='fa fa-edit'></i></button>",
                        "<button class='btn red delete' ><i class='fa fa-trash'></i></button>",
                        terminales[i].Age_cod,
                        terminales[i].Age_nom
                    ]);
                });
            }
        },
        error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
    });

    table.on('click', '.edit', function (e) {
        e.preventDefault();
        table.off("click");

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var cod_term = aData[2];

        var data = { "codigo": cod_term }

        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Mantenedores/editarTerminales",
            data: JSON.stringify(data),
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    var bulto = eval("(" + data.aaData + ")");

                    $("#txtCodigo").val(bulto[0].CODIGO);
                    $("#txtCodigo").prop('disabled', true);
                    $("#txtDescripcion").val(bulto[0].TERMINAL);

                    $("#guardarTerminal").css("display", "none");
                    $("#editarTerminal").css("display", "inline");

                    $("#modalTerminales").modal("show");
                }
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    });

    table.on('click', '.delete', function (e) {
        e.preventDefault();
        table.off("click");
        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var cod_term = aData[2];

        var data = { "codigo": cod_term }

        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Mantenedores/EliminarTerminal",
            data: JSON.stringify(data),
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    cargarTerminales();
                }
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    });
}

function guardarTerminal() {
    var codigo = $("#txtCodigo").val().trim(); //req
    var descripcion = $("#txtDescripcion").val().trim();

    var data = {
        "codigo": codigo,
        "descripcion": descripcion
    }

    if (codigo.length <= 0) ShowError("¡Error¡", "Debe ingresar el codigo");
    else if (descripcion.length <= 0) ShowError("¡Error¡", "Debe ingresar la descripcion");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Mantenedores/guardarTerminal",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#guardarTerminal", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    $("#txtCodigo").val("");
                    $("#txtDescripcion").val("");

                    cargarTerminales();

                    $("#modalTerminales").modal("hide");
                }
            },
            complete: function () {
                ShowProcessing("#guardarTerminal", false, "save");
                //ActivarDesactivarBoton("#btnGuardarDespacho", true);
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}

function editarTerminal() {
    var codigo = $("#txtCodigo").val().trim(); //req
    var descripcion = $("#txtDescripcion").val().trim();

    var data = {
        "codigo": codigo,
        "descripcion": descripcion
    }

    if (codigo.length <= 0) ShowError("¡Error¡", "Debe ingresar el codigo del bulto");
    else if (descripcion.length <= 0) ShowError("¡Error¡", "Debe ingresar la descripcion del bulto");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Mantenedores/guardarTerminalEdit",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#editarTerminal", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();

                    cargarTerminales();

                    $("#modalTerminales").modal("hide");
                }
            },
            complete: function () {
                ShowProcessing("#editarTerminal", false, "save");
                //ActivarDesactivarBoton("#btnGuardarDespacho", true);
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}