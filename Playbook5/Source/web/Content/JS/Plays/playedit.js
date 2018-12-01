function GetPlayDetail(teamId, playId, playbookType) {
    var currentPlayId = playId;
    $.ajax({
        method: "get",
        url: "/Management/Plays/GetPlayDetail?teamId=" + teamId + "&playId=" + playId + "&playbookType=" + playbookType,
        success: function (data) {
            playbookType = playbookType.replace(" ", "_");
            data = data.replace('addplaymodel-' + playbookType, 'editplaymodel-' + playbookType + currentPlayId);
            data = data.replace('Add Play', 'View Play');
            $('#modalcontent').html(data);
            $('#editplaymodel-' + playbookType + currentPlayId).modal('show');
            if (playbookType == 'Archive') {
                $('#editplaymodel-' + playbookType + currentPlayId).find('.editimagswap').remove();
            }
        }
    });
}

function OpenAddPlayPopup(playbookType) {
    playbookType = playbookType.replace(" ", "_");
    $("#addplaymodel-" + playbookType).modal('show');
    EnablePlayFields(this, false);
}

function EnablePlayFields(sender, isChangeTitle) {
    if (isChangeTitle == true) {
        $(sender).siblings("#play-form-title").text("Edit Play");
    }
    $(".edit-play-button").hide();
    $(".play-editable-field").removeAttr('disabled');
    $(".play-navigation-control").show();
}
function DisablePlayFields(sender) {
    $(sender).parent().siblings('.modal-header').find("#play-form-title").text("View Play");
    $(".edit-play-button").show();
    $(".play-editable-field").attr('disabled', 'disabled');
    $(".play-navigation-control").hide();
}

function AddRecommendedPlay(obj) {
    var selectedId = $(obj).siblings('select').val()
    var selectedItems = $(obj).siblings('input[type="hidden"]').val().split(',');
    var alreadySelected = false;
    for (var i = 0; i < selectedItems.length; i++) {
        if (selectedItems[i] == selectedId) {
            alreadySelected = true;
            break;
        }
    }
    if (!alreadySelected) {
        $(obj).siblings('input[type="hidden"]').val($(obj).siblings('input[type="hidden"]').val() + selectedId + ",");
        var itemName = $(obj).siblings('select').find('option:selected').text();
        var html = "<tr><td>" + itemName + "</td><td><a href='javascript:void(0)' onclick=\"RemoveRecommendedPlay(this,'" + selectedId + "')\" class='close'>x</a></td></tr>";
        $(obj).siblings('div').find("#SelectedRecommendedPlays").append(html);

    }
}

function RemoveRecommendedPlay(obj, playId) {
    var selectedItems = $(obj).parents('table').parent().siblings('input[type="hidden"]').val().split(',');
    var alreadySelected = false;
    var newFilteredSelected = "";
    for (var i = 0; i < selectedItems.length; i++) {
        if (selectedItems[i] != "") {
            if (selectedItems[i] != playId) {
                newFilteredSelected = newFilteredSelected + selectedItems[i] + ",";
            }
        }
    }
    $(obj).parents('table').parent().siblings('input[type="hidden"]').val(newFilteredSelected);
    $(obj).parents('tr').remove();
}