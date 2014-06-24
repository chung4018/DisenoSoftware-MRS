$(document).ready(function () {
    $("#submitBusqueda").click(function () {
        alert("Buscar En: "+$('#buscarEn').val());
        var data = JSON.stringify({ stringBuscado: $('#stringBuscado').val(), buscarEn: $('#buscarEn').val() });
        $.ajax({
            type: "POST",
            url: '/BUSQUEDAS/ResultadoBusqueda',
            cache: false,
            data: data,
            dataType: this.dataType,
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                alert("Success" + result);
                /* if (result.IsSuccess) {
                     $("#error_message").html(result.ErrorMessage);
                     $("#error_message").addClass("success");
                     UTMSGrid.StudentCourses.List.bindGrid($("#grid"));
                 }
                 else {
                     $("#error_message").html(result.ErrorMessage);
                     $("#error_message").addClass("fail");
                 }*/
            },
            error: function (data) {
                alert("Error: " + data);
                // $("#error_message").html(data);

            }
        }); // End ajax call
    });
});