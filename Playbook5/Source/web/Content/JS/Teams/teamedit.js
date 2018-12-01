

function EnableFields(controlLocator, btnNavigationLocator) {
    //$("." + controlLocator).removeAttr('disabled');
    //$("." + btnNavigationLocator).show();
    $(".view-team").hide();
    $(".edit-team").show();
}
function DisableFields(controlLocator, btnNavigationLocator) {
    //$("." + controlLocator).attr('disabled', 'disabled');
    //$("." + btnNavigationLocator).hide();
    $(".view-team").show();
    $(".edit-team").hide();
}

function ManageTeamForm(id) {
    if (id == "") {
        EnableFields();
    }
    else {
        DisableFields();
    }
}

function HideErrorMessage() {
    $(".error-message-div").fadeOut();
}

function TeamDetailSectionToggle() {
    $("div#teamDetailSection").toggleClass("hide-view-details");
}