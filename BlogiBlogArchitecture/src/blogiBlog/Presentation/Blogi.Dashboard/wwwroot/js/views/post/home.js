(function () {
    $("#postTable").DataTable({
        "ajax": {
            "type": "GET",
            "url": "/Post/DataTable"
        },       
        "pageLength": 10,
        "bInfo": true,
        "responsive": true,
        "scrollY": false,
        "bPaginate": true,
        "dom": 'Bfrtip',
        "buttons": [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        "columns": [
            {
                "data": "languageName", "autoWidth": true
                ,
                "render": function (data, type, row, meta) {
                    var sanitized = $.fn.dataTable.render.text().display(data, type, row, meta);
                    return sanitized;
                }
            },
            {
                "data": "categoryName", "autoWidth": true
                ,
                "render": function (data, type, row, meta) {
                    var sanitized = $.fn.dataTable.render.text().display(data, type, row, meta);
                    return sanitized;
                }
            },
            {
                "data": "title", "autoWidth": true,
                "render": function (data, type, row, meta) {
                    var sanitized = $.fn.dataTable.render.text().display(data, type, row, meta);
                    return sanitized;
                }
            },
            {
                "data": "isPublished", "autoWidth": true
            },
            {
                "data": "creationDate", "autoWidth": true
            },
            {
                "data": "updationDate", "autoWidth": true
            },
            {
                "data": "id",
                "autoWidth": true,
                "render": function (val) {
                    return '<a href="/Post/Edit?id=' + val + '"  class="btn btn-rounded btn-warning">Update <i class="mdi mdi-upload ml-2"></i></a>';

                }
            },
            {
                "data": "id",
                "autoWidth": true,
                "render": function (val) {
                    return '<button data-model-id="' + val + '" onclick="Delete(this)" class="btn btn-rounded btn-danger">Delete <i class="mdi mdi-delete-sweep ml-2"></i></button>';

                }
            }
        ]
    });
})();


function Delete(obj) {
    var ele = $(obj);
    var Id = ele.data("model-id");

    Swal.fire({
        title: 'Are sure wants to delete?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Post/Delete',
                type: "POST",
                async: true,
                data: { id: Id },
                success: function (result) {

                    if (result.data.success)
                        toastr["success"](result.data.message, "BLOGI BLOG");
                    else
                        toastr["error"](result.data.errors, "BLOGI BLOG");

                    $('#postTable').DataTable().ajax.reload();

                }
            });
        }
    })
};
