var Personas = function () {
    return {
        init: function () {
            cargarPersonas();
            $("#txtRazon").keyup(function () {
                this.value = this.value.toUpperCase();
            });
            $("#txtRut").inputmask("99999999");

            $('#modalPersonas').on('hidden.bs.modal', function () {
                $("#txtRut").val("");
                $("#txtRazon").val("");
                $("#txtPass").val("");
                $("#ddlTerminal").val("");
                $("#ddlFuncion").val("");
                $("#txtRut").prop('disabled', false);

                cargarPersonas();

                $("#guardarPersona").css("display", "inline");
                $("#editarPersona").css("display", "none");
            })
        }
    };
}();

function cargarPersonas() {
    var table = $("#tbpersonas");

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
        url: "/Mantenedores/obtPersonas",
        success: function (dataCS) {
            if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
            else {
                oTable.fnClearTable();
                var personas = eval("(" + dataCS.aaData + ")");
                $.each(personas, function (i) {
                    oTable.fnAddData([
                        "<button class='btn green edit' ><i class='fa fa-edit'></i></button>",
                        "<button class='btn red delete' ><i class='fa fa-trash'></i></button>",
                        personas[i].Rut_persona + '-' + personas[i].Dv_persona,
                        personas[i].Nom_persona,
                        personas[i].Fun_cod,
                        personas[i].Age_cod
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

        var rut_persona = aData[2];
        rut_persona = rut_persona.slice(0, rut_persona.length - 2);

        var data = { "rut_persona": rut_persona }

        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Mantenedores/EditarPersona",
            data: JSON.stringify(data),
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    var persona = eval("(" + data.aaData + ")");

                    $("#txtRut").val(persona[0].rut_persona);
                    $("#txtRut").prop('disabled', true);
                    $("#txtRazon").val(persona[0].nom_persona);
                    $("#txtPass").val(persona[0].pass_persona);
                    $("#ddlTerminal").val(persona[0].age_cod);
                    $("#ddlFuncion").val(persona[0].fun_cod);

                    $("#guardarPersona").css("display", "none");
                    $("#editarPersona").css("display", "inline");

                    $("#modalPersonas").modal("show");
                }
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    });

    table.on('click', '.delete', function (e) {
        e.preventDefault();
        table.off("click");
        var nrow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nrow);

        var rut = aData[2];

        var data = { "rut": rut }

        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Mantenedores/EliminarPersona",
            data: JSON.stringify(data),
            success: function (data) {
                if (data.HasError === true) ShowError("¡Error!", data.Message);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    cargarPersonas();
                }
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    });
}

function guardarPersona() {
    var rut = $("#txtRut").val().trim(); //req
    var nombre = $("#txtRazon").val().trim();
    var password = $("#txtPass").val().trim();
    var terminal = $("#ddlTerminal").val().trim();
    var funcion = $("#ddlFuncion").val().trim();

    var length = rut.length;

    for (var i = 0; i <= length; i++) {
        rut = rut.replace('_', '');
    }

    var data = {
        "rut": rut,
        "nombre": nombre,
        "password": password,
        "terminal": terminal,
        "funcion": funcion
    }

    if (rut.length <= 0) ShowError("¡Error¡", "Debe ingresar el rut");
    else if (nombre.length <= 0) ShowError("¡Error¡", "Debe ingresar el nombre");
    else if (password.length <= 0) ShowError("¡Error¡", "Debe ingresar la contraseña");
    else if (terminal.length <= 0) ShowError("¡Error¡", "Debe ingresar el terminal");
    else if (funcion.length <= 0) ShowError("¡Error¡", "Debe ingresar el funcion");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Mantenedores/GuardarPersona",
            data: JSON.stringify(data),
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    $("#txtRut").val(""); //req
                    $("#txtRazon").val("");
                    $("#txtPass").val("");
                    $("#ddlTerminal").val("");
                    $("#ddlFuncion").val("");

                    cargarPersonas();

                    $("#modalPersonas").modal("hide");
                }
            },
            complete: function () {
                ShowProcessing("#guardarPersona", false, "save");
            },
            error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
        });
    }
}

function editarPersona() {
    var rut = $("#txtRut").val().trim(); //req
    var nombre = $("#txtRazon").val().trim();
    var password = $("#txtPass").val().trim();
    var terminal = $("#ddlTerminal").val().trim();
    var funcion = $("#ddlFuncion").val().trim();

    var largo = rut.length;

    for (var i = 0; i <= largo; i++) {
        rut = rut.replace('_', '');
    }

    var data = {
        "rut": rut,
        "nombre": nombre,
        "password": password,
        "terminal": terminal,
        "funcion": funcion
    }

    if (rut.length <= 0) ShowError("¡Error¡", "Debe ingresar el rut");
    else if (nombre.length <= 0) ShowError("¡Error¡", "Debe ingresar el nombre");
    else if (password.length <= 0) ShowError("¡Error¡", "Debe ingresar la contraseña");
    else if (terminal.length <= 0) ShowError("¡Error¡", "Debe ingresar el terminal");
    else if (funcion.length <= 0) ShowError("¡Error¡", "Debe ingresar el funcion");
    else {
        $.ajax({
            contentType: "application/json; charset=utf-8",
            type: "POST",
            datatype: "json",
            url: "/Mantenedores/GuardarEditPersona",
            data: JSON.stringify(data),
            success: function (data) {
                if (data["HasError"] === true) ShowError("¡Error!", data["Message"]);
                else {
                    ShowSuccess("¡Hecho!", data["Message"]);
                    GoTop();
                    $("#txtRut").val(""); //req
                    $("#txtRazon").val("");
                    $("#txtPass").val("");
                    $("#ddlTerminal").val("");
                    $("#ddlFuncion").val("");

                    cargarPersonas();

                    $("#modalPersonas").modal("hide");
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