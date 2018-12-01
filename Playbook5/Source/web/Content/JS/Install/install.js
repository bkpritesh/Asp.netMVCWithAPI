function GetInstallPlayDetail(teamId, playId) {
    var currentPlayId = playId;
    $.ajax({
        method: "get",
        url: "/Management/Install/GetInstallPlayDetail?teamId=" + teamId + "&playId=" + playId,
        success: function (data) {
            $('#installplayviewdetail').html(data);
            $("#installgrid").hide();
            $("#installplayviewdetail").show();
        }
    });
}

function ChangeImage(obj, imageUrl) {
    var img = $($(obj).parent().siblings()[0]).children('img');
    $(img).attr('src', imageUrl);
}

function EnableInstallGridView() {
    $("#installgrid").show();
    $("#installplayviewdetail").html('');
    $("#installplayviewdetail").hide();
}

function GetInstallTeamDetail(teamId, installId) {
    var currentInstallId = installId;
    $.ajax({
        method: "get",
        url: "/Management/Install/GetInstallDetailPartial?teamId=" + teamId + "&installId=" + currentInstallId,
        success: function (data) {
            data = data.replace('addinstallmodel', 'editinstallmodel-' + currentInstallId);
            data = data.replace('Add Install', 'Edit Install');
            $('#modalcontent').html(data);
            $('#editinstallmodel-' + currentInstallId).modal('show');
            ConfigureDatePicker();
        }
    });
}

function ConfigureDatePicker() {
    $('.datetimepicker').datepicker({
        format: 'mm/dd/yyyy'
    });
}

$(document).ready(function () {
    ConfigureDatePicker();
})