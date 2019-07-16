var clickValidado = false;
$(document).ready(function () {
    Metronic.init();
    Layout.init();
    SessionControl.init();


});

//$(document).click(function () {
//    //validar la cookie ante cualquier evento de la pagina ya sea botones, links, etc..
//    $.ajax({
//        contentType: "application/json; charset=utf-8",
//        type: "POST",
//        datatype: "json",
//        url: "/Saam.Web.Trf/Home/ValSession",
//        success: function (data) {
//            if ($.trim(data.Cookie) === "") window.location = "/Saam.Web.Trf/Session/CerrarSession";
//        },
//    });
//});

$("body").on("click", ".aMenuLink", function () { clickValidado = true; });

$(document).trigger("click");

$("body").on("change", ":text", function (i) { $(this).val($(this).val().toUpperCase()); });

$("body").on("keydown", ".form-control", function (e) {
    if (e.which === 13) {
        var count = 1;
        var index = $('.form-control').index(this) + count;
        while ($('.form-control').eq(index).prop("disabled") || $('.form-control').eq(index).hasClass("disabled") || $('.form-control').eq(index).prop("readonly")) {
            count++;
            index = $('.form-control').index(this) + count;
        }
        $('.form-control').eq(index).focus();
    }
});

$("body").on("change", ".txtDecimalFormato", function () {
    $(this).val($(this).val().replace(",", "."));
    if ($.trim($(this).val()) == "") $(this).val("");
    else {
        if (isNaN($(this).val())) {
            ShowError("¡Error!", "Debe ingresar un número");
            $(this).val("0");
        }
        else $(this).val(parseFloat($(this).val()).toFixed($(this).attr("data-decimales")));
    }
});