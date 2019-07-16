var ClientesMnt = function () {
    return {
        init: function () {
            cargarClientes();
            $("#txtRazon").keyup(function () {
                this.value = this.value.toUpperCase();
            });
            $("#txtRut").inputmask("99999999");

            $('#modalCliente').on('hidden.bs.modal', function () {
                $("#txtRut").val("");
                $("#txtRazon").val("");
                $("#txtPass").val("");
                $("#txtMail").val("");
                $("#txtFono").val("");
                $("#txtRut").prop('disabled', false);

                cargarClientes();

                $("#guardarCliente").css("display", "inline");
                $("#editarCliente").css("display", "none");
            })
        }
    };
}();

function cargarClientes() {
    var table = $("#tbClientes");

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
        url: "obtClientes",
        success: function (dataCS) {
            if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
            else {
                oTable.fnClearTable();
                var clientes = eval("(" + dataCS.aaData + ")");
                $.each(clientes, function (i) {
                    oTable.fnAddData([
                        "<button class='btn green edit' ><i class='fa fa-edit'></i></button>",
                        "<button class='btn red delete' ><i class='fa fa-trash'></i></button>",
                        clientes[i].Rut_cliente + '-' + clientes[i].Dv_cliente,
                        clientes[i].Nombre_cliente,
                        clientes[i].Pass_cliente
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

        var rut_cliente = aData[2];
        rut_cliente = rut_cliente.slice(0, rut_cliente.length - 2);

        var data = { "rut_cliente": rut_cliente }

        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "EditarCliente",
            data: JSON.stringify(data),
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    var cliente = eval("(" + data.aaData + ")");

                    $("#txtRut").val(cliente[0].rut_cliente);
                    $("#txtRut").prop('disabled', true);
                    $("#txtRazon").val(cliente[0].nombre_cliente);
                    $("#txtPass").val(cliente[0].pass_cliente);
                    $("#txtMail").val(cliente[0].email_cliente);
                    $("#txtFono").val(cliente[0].fono_cliente);

                    $("#guardarCliente").css("display", "none");
                    $("#editarCliente").css("display", "inline");

                    $("#modalCliente").modal("show");
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

        var rut_cliente = aData[2];

        var data = { "rut": rut_cliente }

        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "EliminarCliente",
            data: JSON.stringify(data),
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    cargarClientes();
                }
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    });
}

function guardarCliente() {
    var rut = $("#txtRut").val().trim(); //req
    var nombre = $("#txtRazon").val().trim();
    var password = $("#txtPass").val().trim();
    var mail = $("#txtMail").val().trim();
    var fono = $("#txtFono").val().trim();

    var length = rut.length;

    for (var i = 0; i <= length; i++) {
        rut = rut.replace('_', '');
    }

    var data = {
        "rut": rut,
        "nombre": nombre,
        "password": password,
        "mail": mail,
        "fono": fono
    }

    if (rut.length <= 0) ShowError("¡Error¡", "Debe ingresar el rut del cliente");
    else if (nombre.length <= 0) ShowError("¡Error¡", "Debe ingresar el nombre del cliente");
    else if (password.length <= 0) ShowError("¡Error¡", "Debe ingresar la contraseña para este cliente");
    else if (mail.length <= 0) ShowError("¡Error¡", "Debe ingresar el mail");
    else if (fono.length <= 0) ShowError("¡Error¡", "Debe ingresar el fono del cliente");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "GuardarCliente",
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
                    $("#txtRut").val(""); //req
                    $("#txtRazon").val("");
                    $("#txtPass").val("");
                    $("#txtMail").val("");
                    $("#txtFono").val("");

                    cargarClientes();

                    $("#modalCliente").modal("hide");
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

function editarCliente() {
    var rut = $("#txtRut").val().trim(); //req
    var nombre = $("#txtRazon").val().trim();
    var password = $("#txtPass").val().trim();
    var mail = $("#txtMail").val().trim();
    var fono = $("#txtFono").val().trim();

    var largo = rut.length;

    for (var i = 0; i <= largo; i++) {
        rut = rut.replace('_', '');
    }

    var data = {
        "rut": rut,
        "nombre": nombre,
        "password": password,
        "mail": mail,
        "fono": fono
    }

    if (rut.length <= 0) ShowError("¡Error¡", "Debe ingresar el rut del cliente");
    else if (nombre.length <= 0) ShowError("¡Error¡", "Debe ingresar el nombre del cliente");
    else if (password.length <= 0) ShowError("¡Error¡", "Debe ingresar la contraseña para este cliente");
    else if (mail.length <= 0) ShowError("¡Error¡", "Debe ingresar el mail");
    else if (fono.length <= 0) ShowError("¡Error¡", "Debe ingresar el fono del cliente");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "GuardarEditCliente",
            data: JSON.stringify(data),
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    $("#txtRut").val(""); //req
                    $("#txtRazon").val("");
                    $("#txtPass").val("");
                    $("#txtMail").val("");
                    $("#txtFono").val("");

                    cargarClientes();

                    $("#modalCliente").modal("hide");
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