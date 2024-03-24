var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "13%" },
            { data: 'price', "width": "13%" },
            { data: 'quantity', "width": "13%" },
            { data: 'maker', "width": "13%" },
            { data: 'description', "width": "13%" },
            { data: 'category.name', "width": "13%" },
            {
                data: 'id',
                render: function (data, type, row) {
                    return `<div class="w-75 btn-group" role="group">
                                <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>Edit</a>
                                <a onClick="Delete('/admin/product/delete/${data}')" class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i>Delete</a>
                                <a onClick="OrderMore('${row.title}','${row.maker}')" class="btn btn-primary mx-2"><i ></i>Order more</a>
                           </div>`;
                },
                "width": "15%"
            },


        ]
    });

}
s

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        };
    })
};

function OrderMore(title,maker) {
    // Show SweetAlert dialog for ordering more
    Swal.fire({
        title: "Order more copies of " + title,
        html: '<div>add a message to the creator (' + maker +'):</div>' +
            '<input id="swal-message" class="swal2-input" placeholder="Write your message here...(optional)">' +
            '<div>enter order amount:</div>' +
            '<input id="swal-quantity" class="swal2-input" placeholder="quantity">',
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Send order!",
        allowOutsideClick: false, // Prevent closing on outside click
        allowEscapeKey: false // Prevent closing on ESC key
    }).then((result) => {
        // Check if user confirmed the action
        if (result.isConfirmed) {
            // Get the input quantity
            const quantityInput = document.getElementById('swal-quantity');
            const quantity = parseInt(quantityInput.value); // Convert input value to integer

            // Check if quantity is empty or not a number or out of range
            if (isNaN(quantity) || quantity < 1 || quantity > 100) {
                // Show error message
                Swal.fire({
                    title: "Invalid Quantity",
                    text: "Please enter a valid quantity between 1 and 100.",
                    icon: "error",
                    confirmButtonText: "OK"
                });
                // Keep the Swal open
                return false;
            } else {
                // If quantity is valid, get the optional message
                const message = document.getElementById('swal-message').value;
                // Proceed with your logic here, for now, just show a success message
                Swal.fire({
                    title: "Order Sent!",
                    text: "Your order has been sent to: " + maker + "@Email.com"+"\n Well contact you as soon as they respond",
                    icon: "success",
                    confirmButtonText: "OK"
                });
            }
        }
    });
}

