var dataTable

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable(
        {
            "ajax": {
                "url": "/Customer/Home/GetAll"
            },
            "columns": [
                {

                    "data": "listImageUrl",
                    "render": function (data) {
                        console.log(data);
                        return `

                            <div style="position: relative;height: 15vh; width: 20vh">
                                <img src="${data}" style=" top: 0; left: 0; width: 100%; height: 100%; object-fit: cover;"/>
                            </div>
                        `
                    },
                    "className": "text-center",
                    "width": "20%",
                    "responsivePriority": 1
                },
                { "data": "marca", "width": "20%","className": "text-center" },
                { "data": "model", "width": "20%", "className": "text-center" },
                { "data": "anFabricatie", "width": "20%", "className": "text-center" },
                {
                    "data": "pret",
                    "width": "20%",
                    "className": "text-center",
                    "render": function (data) {
                        return data.toFixed(2) +" €";
                    }
                }

                
            ],
            //remove the order icon from first column
            "columnDefs": [
                { "orderable": false, "targets": 0 }
            ],
            "order": [[3, "asc"]]
        }
    );

    //// Add click listener to cells instead of rows
    //$('#tblData tbody').on('click', 'img', function () {
    //    var row = $(this).closest('tr');
    //    var data = dataTable.row(row).data();
    //    if (data) {
    //        window.location.href = '/Customer/Home/Details/' + data.id;
    //    }
    //});

    $('#tblData tbody').on('click', 'td', function () {
        var cell = dataTable.cell(this).node();
        var data = dataTable.row($(cell).parent()).data();
        if (data) {
            window.location.href = '/Customer/Home/Details/' + data.id;
        }
    });

    //// Change cursor to pointer on hover
    //$('#tblData tbody').on('mouseenter', 'img', function () {
    //    $(this).css('cursor', 'pointer');
    //}).on('mouseleave', 'td', function () {
    //    $(this).css('cursor', 'auto');
    //});

    $('#tblData tbody').on('mouseenter', 'td', function () {
        $(this).css('cursor', 'pointer');
    }).on('mouseleave', 'td', function () {
        $(this).css('cursor', 'auto');
    });

}