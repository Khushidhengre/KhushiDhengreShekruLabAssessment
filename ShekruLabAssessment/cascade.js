$(document).ready(function () {
    $("#designation").attr('disable', true);
    $("#designationgrade").attr('disable', true);
    LoadDesignation();
});

function LoadDesignation() {
    $("#designation").empty();

    $.ajax({
        url: '/Curd/GetDesignation',
        success: function (response) {
            if (res != null) {
                $("#designation").attr('disable', false);
                $("#designation").append('<option>--Select designation--</option>');
                $("#designationgrade").append('<option>--Select designation grade--</option>');
                $.each(response, function (i, data) {
                    $("#designation").append('<option value =' + data.Id + '>' + data.DesignationName + '</option>' );
               


            }
          
        },
        error: function (error) {
            alert(error);
        }

    })
}