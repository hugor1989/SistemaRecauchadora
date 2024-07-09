﻿
var tabladata;
$(document).ready(function () {
    activarMenu("Producción");


    ////validamos el formulario
    $("#form").validate({
        rules: {
            Descripcion: "required",
            MetrajeBanda: "required"
        },
        messages: {
            Descripcion: "(*)",
            MetrajeBanda: "(Mayor a 1)"

        },
        errorElement: 'span'
    });


    tabladata = $('#tbdata').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerMedidaLlantas,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Descripcion" },
            { "data": "MetrajeBanda" },
            {
                "data": "Activo", "render": function (data) {
                    if (data) {
                        return '<span class="badge badge-success">Activo</span>'
                    } else {
                        return '<span class="badge badge-danger">No Activo</span>'
                    }
                }
            },
            {
                "data": "IdMedidaLlanta", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-primary btn-sm' type='button' onclick='abrirPopUpForm(" + JSON.stringify(row) + ")'><i class='fas fa-pen'></i></button>" +
                        "<button class='btn btn-danger btn-sm ml-2' type='button' onclick='eliminar(" + data + ")'><i class='fa fa-trash'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            }

        ],
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        },
        responsive: true
    });


})


function abrirPopUpForm(json) {

    $("#txtid").val(0);

    if (json != null) {

        $("#txtid").val(json.IdMedidaLlanta);

        $("#txtDescripcion").val(json.Descripcion);
        $("#txtMetrajeBanda").val(json.MetrajeBanda);
        $("#cboEstado").val(json.Activo == true ? 1 : 0);

    } else {
        $("#txtDescripcion").val("");
        $("#txtMetrajeBanda").val(1);
        $("#cboEstado").val(1);
    }

    $('#FormModal').modal('show');

}


function Guardar() {

    if ($("#form").validate()) {

        var request = {
            objeto: {
                IdMedidaLlanta: parseInt($("#txtid").val()),
                Descripcion: $("#txtDescripcion").val(),
                MetrajeBanda: $("#txtMetrajeBanda").val(),
                Activo: ($("#cboEstado").val() == "1" ? true : false)
            }
        }

        jQuery.ajax({
            url: $.MisUrls.url._GuardarMedidaLlanta,
            type: "POST",
            data: JSON.stringify(request),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tabladata.ajax.reload();
                    $('#FormModal').modal('hide');
                } else {

                    swal("Mensaje", "No se pudo guardar los cambios", "warning")
                }
            },
            error: function (error) {
                console.log(error)
            },
            beforeSend: function () {

            },
        });

    }

}


function eliminar($id) {


    swal({
        title: "Mensaje",
        text: "¿Desea eliminar la marca del llanta seleccionada?",
        type: "warning",
        showCancelButton: true,

        confirmButtonText: "Si",
        confirmButtonColor: "#DD6B55",

        cancelButtonText: "No",

        closeOnConfirm: true
    },

        function () {
            jQuery.ajax({
                url: $.MisUrls.url._EliminarMedidaLlanta + "?id=" + $id,
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.resultado) {
                        tabladata.ajax.reload();
                    } else {
                        swal("Mensaje", "No se pudo eliminar la marca del llanta", "warning")
                    }
                },
                error: function (error) {
                    console.log(error)
                },
                beforeSend: function () {

                },
            });
        });

}