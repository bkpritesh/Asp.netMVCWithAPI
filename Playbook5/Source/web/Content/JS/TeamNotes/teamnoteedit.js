function GetTeamNoteDetail(teamId, Id) {
    $.ajax({
        method: "get",
        url: "/Management/Install/GetTeamNoteDetail?teamId=" + teamId + "&Id=" + Id,
        success: function (data) {
            data = data.replace('addteamnotemodel', 'editteamnotemodel');
            data = data.replace('Add Notes', 'Edit Notes');
            $('#modalcontent').html(data);
            $('#editteamnotemodel').modal('show');
        }
    });
}