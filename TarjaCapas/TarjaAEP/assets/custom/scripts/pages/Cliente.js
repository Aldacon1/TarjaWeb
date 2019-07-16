var Cliente = function () {
    return {
        init: function () {
            CargarDesc();
            CargarCons();
            CargarDesp();
        }
    };
}();


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
        url: "/Cliente/ObtLisDesc",
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

        var contenedor = aData[4];

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
            url: "/Cliente/obtLinksVideo",
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

function CargarCons() {
    var table = $("#tbConso");

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
        url: "/Cliente/ObtLisCons",
        success: function (dataCS) {
            if (dataCS.TieneError === true) ShowError("¡Error!", dataCS.Mensaje);
            else {
                oTable.fnClearTable();
                var planes = eval("(" + dataCS.aaData + ")");
                var btnDown, btnZip;
                $.each(planes, function (i) {
                    if (planes[i].ESTADO == "Cerradas") {
                        btnDown = "<button class='btn blue download' ><i class='fa fa-cloud-download'></i></button>";
                        btnZip = "<button class='btn blue zip' ><i class='fa fa-file-zip-o'></i></button>";
                    }
                    else {
                        btnDown = "";
                        btnZip = "";
                    }
                    oTable.fnAddData([
                        planes[i].NROTARJA,
                        planes[i].CLIENTE,
                        planes[i].CONTENEDOR,
                        planes[i].FECHA,
                        planes[i].TERMINAL,
                        planes[i].ESTADO,
                        btnDown,
                        btnZip
                    ]);
                });
            }
        },
        error: function (event, jqxhr, settings, exception) { ShowError("¡Error!", "Falló la conexión con el servidor."); }
    });

    table.on('click', '.download', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var nro_tarja = aData[0];
        var estado = aData[10];
        window.open("CrearPdfConso?nro_tarja=" + nro_tarja);
    });

    table.on('click', '.zip', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var nro_tarja = aData[0];
        var estado = aData[10];
        window.open("DownloadZip?nro_tarja=" + nro_tarja);
    });
}

function CargarDesp() {
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
        url: "/Cliente/ObtLisDesp",
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

    table.on('click', '.download', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var nro_tarja = aData[0];
        var estado = aData[10];
        window.open("CrearPdfDespacho?nro_tarja=" + nro_tarja);
    });

    table.on('click', '.zip', function (e) {
        e.preventDefault();

        var nRow = $(this).parents('tr')[0];
        var aData = oTable.fnGetData(nRow);

        var nro_tarja = aData[0];
        var estado = aData[10];
        window.open("DownloadZipDesp?nro_tarja=" + nro_tarja);
    });
}