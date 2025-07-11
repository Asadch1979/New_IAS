$(document).ready(function () {
    $('#searchBtn').on('click', function () {
        searchReferenceUpdates();
    });

    $(document).on('click', '.edit-btn', function () {
        var id = $(this).data('id');
        $('#editModal').load(g_asiBaseURL + '/FAD/ReferenceUpdateEdit?comId=' + id, function () {
            $('#editModal').modal('show');
        });
    });

    $(document).on('click', '.log-btn', function () {
        var id = $(this).data('id');
        $('#logModal').load(g_asiBaseURL + '/FAD/ReferenceUpdateLog?comId=' + id, function () {
            $('#logModal').modal('show');
        });
    });

    $(document).on('click', '#saveReferenceBtn', function () {
        var comId = $(this).data('comid');
        var newRef = $('#editReferenceId').val();
        var updatedBy = $('#currentUser').val();
        $.ajax({
            url: g_asiBaseURL + '/ApiCalls/UpdateParaReference',
            type: 'POST',
            data: { comId: comId, newRef: newRef, updatedBy: updatedBy },
            success: function (res) {
                alert(res.remarks);
                $('#editModal').modal('hide');
                $('#searchBtn').click();
            }
        });
    });
});

function searchReferenceUpdates() {
    var entId = $('#entityDropdown').val();
    var auditorId = $('#auditorDropdown').val();
    var referenceId = $('#referenceDropdown').val();
    $.ajax({
        url: g_asiBaseURL + '/ApiCalls/GetObservationsForReferenceUpdate',
        type: 'GET',
        data: { entId: entId, assignedAuditorId: auditorId, referenceId: referenceId },
        success: function (data) {
            var tbody = $('#referenceUpdateTable tbody');
            tbody.empty();
            $.each(data, function (i, item) {
                var row = '<tr>' +
                    '<td>' + item.ParaTitle + '</td>' +
                    '<td>' + item.ReferenceId + '</td>' +
                    '<td>' + item.ReferenceType + '</td>' +
                    '<td>' + item.AssignedAuditor + '</td>' +
                    '<td>' + item.Status + '</td>' +
                    '<td>' + item.UpdatedBy + '</td>' +
                    '<td>' + item.UpdatedOn + '</td>' +
                    '<td>' + item.Remarks + '</td>' +
                    '<td><button class="btn btn-sm btn-primary edit-btn" data-id="' + item.ComId + '">Edit</button> ' +
                    '<button class="btn btn-sm btn-info log-btn" data-id="' + item.ComId + '">Log</button></td>' +
                    '</tr>';
                tbody.append(row);
            });
            initializeDataTable('referenceUpdateTable');
        }
    });
}
