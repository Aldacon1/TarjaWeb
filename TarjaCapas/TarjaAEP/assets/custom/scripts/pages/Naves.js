var Naves = function () {
    return {
        init: function () {
            cargarNaves();
            $("#txtNombre").keyup(function () {
                this.value = this.value.toUpperCase();
            });

            $('#modalNaves').on('hidden.bs.modal', function () {
                $("#txtCodigo").val("");
                $("#txtNombre").val("");
                $("#txtCodigo").prop('disabled', false);

                $("#guardarNave").css("display", "inline");
                $("#editarNave").css("display", "none");
            })
        }
    };
}();

function cargarNaves() {
    var table = $("#tbNaves");

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
        url: "/Mantenedores/obtNaves",
        success: function (dataCS) {
            if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
            else {
                oTable.fnClearTable();
                var naves = eval("(" + dataCS.aaData + ")");
                $.each(naves, function (i) {
                    oTable.fnAddData([
                        "<button class='btn green edit' ><i class='fa fa-edit'></i></button>",
                        "<button class='btn red delete' ><i class='fa fa-trash'></i></button>",
                        naves[i].Nav_cod,
                        naves[i].Nav_nom
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

        var cod_nave = aData[2];

        var data = { "codigo": cod_nave }

        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Mantenedores/EditarNaves",
            data: JSON.stringify(data),
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    var nave = data.aaData;

                    $("#txtCodigo").val(nave.Nav_cod);
                    $("#txtCodigo").prop('disabled', true);
                    $("#txtNombre").val(nave.Nav_nom);

                    $("#guardarNave").css("display", "none");
                    $("#editarNave").css("display", "inline");

                    $("#modalNaves").modal("show");
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

        var cod_bulto = aData[2];

        var data = { "codigo": cod_bulto }

        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Mantenedores/EliminarNave",
            data: JSON.stringify(data),
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    cargarNaves();
                }
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    });
}

function guardarNave() {
    var codigo = $("#txtCodigo").val().trim(); //req
    var descripcion = $("#txtNombre").val().trim();

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
            url: "/Mantenedores/GuardarNave",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#guardarNave", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    $("#txtCodigo").val("");
                    $("#txtNombre").val("");

                    cargarNaves();

                    $("#modalNaves").modal("hide");
                }
            },
            complete: function () {
                ShowProcessing("#guardarNave", false, "save");
                //ActivarDesactivarBoton("#btnGuardarDespacho", true);
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}

function editarNave() {
    var codigo = $("#txtCodigo").val().trim(); //req
    var descripcion = $("#txtNombre").val().trim();

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
            url: "/Mantenedores/GuardarNaveEdit",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#editarNave", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();

                    cargarNaves();

                    $("#modalNaves").modal("hide");
                }
            },
            complete: function () {
                ShowProcessing("#editarNave", false, "save");
                //ActivarDesactivarBoton("#btnGuardarDespacho", true);
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}