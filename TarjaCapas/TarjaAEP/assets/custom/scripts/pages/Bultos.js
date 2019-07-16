var Bultos = function () {
    return {
        init: function () {
            cargarBultos();
            $("#txtDescripcion").keyup(function () {
                this.value = this.value.toUpperCase();
            });

            $('#modalBultos').on('hidden.bs.modal', function () {
                $("#txtCodigo").val("");
                $("#txtDescripcion").val("");
                $("#txtCodigo").prop('disabled', false);

                $("#guardarBulto").css("display", "inline");
                $("#editarBulto").css("display", "none");
            });
        }
    };
}();

function cargarBultos() {
    var table = $("#tbBultos");

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
        url: "/Mantenedores/obtBultos",
        success: function (dataCS) {
            if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
            else {
                oTable.fnClearTable();
                var bultos = eval("(" + dataCS.aaData + ")");
                $.each(bultos, function (i) {
                    oTable.fnAddData([
                        "<button class='btn green edit' ><i class='fa fa-edit'></i></button>",
                        "<button class='btn red delete' ><i class='fa fa-trash'></i></button>",
                        bultos[i].Cod_bulto,
                        bultos[i].Desc_bulto
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

        var cod_bulto = aData[2];

        var data = { "codigo": cod_bulto }

        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Mantenedores/EditarBultos",
            data: JSON.stringify(data),
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    var bulto = eval("(" + data.aaData + ")");

                    $("#txtCodigo").val(bulto[0].CODIGO);
                    $("#txtCodigo").prop('disabled', true);
                    $("#txtDescripcion").val(bulto[0].NOMBRE);

                    $("#guardarBulto").css("display", "none");
                    $("#editarBulto").css("display", "inline");

                    $("#modalBultos").modal("show");
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
            url: "/Mantenedores/EliminarBulto",
            data: JSON.stringify(data),
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    cargarBultos();
                }
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    });
}

function guardarBulto() {
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
            url: "/Mantenedores/GuardarBulto",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#guardarBulto", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    $("#txtCodigo").val("");
                    $("#txtDescripcion").val("");

                    cargarBultos();

                    $("#modalBultos").modal("hide");
                }
            },
            complete: function () {
                ShowProcessing("#guardarBulto", false, "save");
                //ActivarDesactivarBoton("#btnGuardarDespacho", true);
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}

function editarBulto() {
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
            url: "/Mantenedores/GuardarBultoEdit",
            data: JSON.stringify(data),
            beforeSend: function () {
                ShowProcessing("#editarBulto", true, "");
                //ActivarDesactivarBoton("#btnGuardarDespacho", false);
            },
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();

                    cargarBultos();

                    $("#modalBultos").modal("hide");
                }
            },
            complete: function () {
                ShowProcessing("#editarBulto", false, "save");
                //ActivarDesactivarBoton("#btnGuardarDespacho", true);
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}