//********************************************************//
// Función:  ValidateEmail
// Objetivo: Valida el formato correcto de email
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
function ValidateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

//********************************************************//
// Función:  ValidateDres
// Objetivo: Valida el formato correcto de email
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
function ValidateDres(dres) {
    var dresReturn = dres.trim().split("-");
    if (dresReturn.length !== 2 || isNaN(dresReturn[0]) || isNaN(dresReturn[1])) {
        ShowError("¡Error!", "Formato DRES inválido");
        dresReturn = [];
    }

    return dresReturn;
}

//********************************************************//
// Función:  ValidateRut
// Objetivo: Valida el formato de rut válido
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
function ValidateRut(rut) {
    if (rut.toString().trim() !== "" && rut.toString().indexOf("-") > 0) {
        var caracteres = new Array();
        var serie = new Array(2, 3, 4, 5, 6, 7);
        var dig = rut.toString().substr(rut.toString().length - 1, 1);
        rut = rut.toString().substr(0, rut.toString().length - 2);

        for (var i = 0; i < rut.length; i++) {
            caracteres[i] = parseInt(rut.charAt((rut.length - (i + 1))));
        }

        var sumatoria = 0;
        var k = 0;
        for (var j = 0; j < caracteres.length; j++) {
            if (k === 6) {
                k = 0;
            }
            sumatoria += parseInt(caracteres[j]) * parseInt(serie[k]);
            k++;
        }

        var resto = sumatoria % 11;
        var dv = 11 - resto;

        if (dv === 10) {
            dv = "K";
        } else if (dv === 11) {
            dv = 0;
        }

        if (dv.toString().trim().toUpperCase() === dig.toString().trim().toUpperCase())
            return true;
        else
            return false;
    } else {
        return false;
    }
}

//********************************************************//
// Función:  ZeroLeft
// Objetivo: Llena de ceros a la izquierda
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
function ZeroLeft(word, lenght) {
    word = word.toString();
    var zeroString = "";
    var negativeLenght = lenght * -1;
    for (var i = 0; i < lenght; i++) {
        zeroString += "0";
    }
    var returnValue = (zeroString + word).slice(negativeLenght);
    return returnValue;
}

//********************************************************//
// Función:  SplitContenedor
// Objetivo: Devuelve sigla-numero-dígito de un contenedor
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
function SplitContenedor(contenedor) {
    var splitedCnt = new Object();
    if (contenedor.indexOf("-") > -1) {
        splitedCnt["sigla"] = contenedor.substring(0, 4).toUpperCase();
        splitedCnt["numero"] = contenedor.split("-")[0].substring(4);
        splitedCnt["digito"] = contenedor.split("-")[1];

        if (isNaN(splitedCnt["numero"])) {
            ShowError("¡Error!", "Formato de contenedor inválido");
            splitedCnt["sigla"] = null;
        }
    } else {
        ShowError("¡Error!", "Formato de contenedor inválido");
    }

    return splitedCnt;
}

//********************************************************//
// Función:  SplitContenedorTarja
// Objetivo: Devuelve sigla-numero-dígito de un contenedor
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
function SplitContenedorTarja(contenedor) {
    var splitedCnt = new Object();
    splitedCnt["sigla"] = contenedor.substring(0, 4).toUpperCase();
    splitedCnt["numero"] = contenedor.substring(4,10);
    splitedCnt["digito"] = contenedor.substring(10);

    if (isNaN(splitedCnt["numero"])) {
        ShowError("¡Error!", "Formato de contenedor inválido");
        splitedCnt["sigla"] = null;
    }

    return splitedCnt;
}

//********************************************************//
// Función:    DataBind
// Parámetros: 
// Objetivo:   Obtiene todos los datos para una tabla
// Autor:      Isaias Peña Cromilakis
// Fecha:      14/01/2014
//********************************************************//
function DataBind(tableId, method, data, columnDefs, displayLenght) {
    if (typeof displayLenght === "undefined") {
        displayLenght = 10;
    }

    if (typeof columnDefs === "undefined") {
        columnDefs = [];
    }

    $("#" + tableId).dataTable({
        destroy: true,
        bProcessing: false,
        sAjaxSource: method,
        "fnServerParams": function (aoData) {
            if (typeof data !== "undefined") {
                for (var i = 0; i < data.length; i++) {
                    aoData.push(data[i]);
                }
            }
        },
        "columnDefs": columnDefs,
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
        'iDisplayLength': displayLenght, //10 Registros por página
        'bLengthChange': false, //No se puede cambiar la cantidad de registros por página
        "bInfo": false, //No se muestra mensaje de información de registros
        "bFilter": false, //No se muestra cuadro de búsqueda
        "bSort": false //No se muestra flecha para reordenar
    });
}

//********************************************************//
// Función:    DeleteRow
// Parámetros: - row:  
//
// Objetivo:   Eliminar un una fila de una tabla
// Autor:      Isaias Peña Cromilakis
// Fecha:      12/01/2014
//********************************************************//
function DeleteRow(row) {
    var node = row.parentNode.parentNode;
    node.parentNode.removeChild(node);
}

//********************************************************//
// Función:    CleanTable
// Parámetros: 
// Objetivo:   Limpia todas las filas de una tabla
// Autor:      Isaias Peña Cromilakis
// Fecha:      19/01/2014
//********************************************************//
function CleanTable(table) {
    var rowCount = table.getElementsByTagName("tr").length - 1;
    for (var i = rowCount; i > 0; i--) {
        table.deleteRow(i);
    }
}

//********************************************************//
// Función:    GoTop
// Parámetros: 
// Objetivo:   Lleva al top de una página
// Autor:      Isaias Peña Cromilakis
// Fecha:      19/01/2014
//********************************************************//
function GoTop() {
    $("html, body").animate({ scrollTop: 0 }, "slow");
}

//********************************************************//
// Función:    GoTop
// Parámetros: 
// Objetivo:   Lleva al top de una página
// Autor:      Isaias Peña Cromilakis
// Fecha:      19/01/2014
//********************************************************//
function CreateId() {
    var d = new Date();
    //año-mes-dia-hora-minuto-segundo-milisegundo-aleatorio
    var retorno = "" + d.getFullYear() + d.getMonth() + d.getDay() + d.getHours() + d.getMinutes() + d.getSeconds() + d.getMilliseconds() + (Math.floor(Math.random() * 90000) + 10000);
    return retorno;
}

//********************************************************//
// Función:  Performance
// Objetivo: Analiza el tiempo de ejecución de un método
// Autor:    Isaias Peña Cromilakis
// Fecha:    24/12/2014
//********************************************************//
var Performance = function () {
    this.startTimer = function () {
        this.start = new Date().getTime();
    };

    this.stopTimer = function () {
        return (new Date().getTime()) - this.start;
    };
};

//********************************************************//
// Función:  Solo Numeros
// Objetivo: Clase que permite que a un textbox se le pueda ingresar solo numeros
// Autor:    Diego Hernandez
// Fecha:    12/05/2015
//********************************************************//
$("body").on("keydown", ".OnlyNumbers", function (e) {
    var tecla = (document.all) ? e.keyCode : e.which;
    if (tecla === 8) return true;
    if (tecla === 9) return true;
    if (tecla === 44) return false; // si recibe una coma
    if (tecla === 46) return false; // si recibe un punto
    if ((tecla >= 96) && (tecla <= 105)) return true;
    if (isNaN(parseInt(String.fromCharCode(tecla)))) {
        return false;
    } else {
        if ($.trim($(this).val()) === "") $(this).val("0");
        return true;
    }
});

//********************************************************//
// Función:  Solo Numeros y Decimales
// Objetivo: Clase que permite que a un textbox se le pueda ingresar solo numeros con decimales
// Autor:    Diego Hernandez
// Fecha:    12/05/2015
//********************************************************//
$("body").on("keydown", ".OnlyNumbersDecimal", function (e) {
    var tecla = (document.all) ? e.keyCode : e.which;
    if (tecla === 188) return true; // si recibe una coma
    if (tecla === 190 || tecla === 110) return true; // si recibe un punto
    if (tecla === 8) return true;
    if (tecla === 9) return true;
    if ((tecla >= 96) && (tecla <= 105)) return true;
    if (isNaN(parseInt(String.fromCharCode(tecla)))) {
        return false;
    } else {
        return true;
    }
});