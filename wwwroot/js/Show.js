$(document).ready(function () {
    // Setup - add a text input to each footer cell

    $('#showGrid tfoot th').each(function (i) {
        var title = $('#showGrid thead th').eq($(this).index()).text();
        $(this).html('<input type="text" placeholder="Search this page ' + title + '" data-index="' + i + '" />');
    });
    // DataTable

    var table = $('#showGrid').DataTable({
        scrollY: "500px",
        scrollX: true,
        scrollCollapse: false,
        paging: false,
        fixedColumns: true
    });

    // Filter event handler

    $(table.table().container()).on('keyup', 'tfoot input', function () {
        table
            .column($(this).data('index'))
            .search(this.value)
            .draw();
    });
});
