$(document).ready(function () {
    showAllCustomer();

    function showAllCustomer() {

        $(".table tbody").html("");

        $.ajax({
            url: "http://localhost:5022/api/ProductsControllers",
            type: "get",
            contentType: "application/json",
            success: function (result) {
                $.each(result, function (index, value) {
                    var appendElement = $("<tr>");
                    appendElement.append($("<td>").html(value["productId"]));
                    appendElement.append($("<td>").html(value["productName"]));
                    appendElement.append($("<td>").html(value["unitsInStock"]));
                    appendElement.append($("<td>").html(value["unitPrice"]));

                    appendElement.append($("<td>").html(`
                        <a href="/Product/Edit?id=${value["productId"]}">
                            <img src="/images/edit-icon.png" alt="Edit" style="width: 40px; height: 40px;" />
                        </a>`));

                    appendElement.append($("<td>").html(`
                        <img src="/images/delete-icon.png" alt="Delete" style="width: 40px; height: 40px;" class="delete" data-id="${value["productId"]}" />
                    `));

                    $(".table tbody").append(appendElement);
                });
            },
            error: function (xhr) {
                console.log(xhr);
            }
        });
    }
    $(document).on('click', '.delete', function () {
        var productId = $(this).data('id');
        if (confirm("Are you sure you want to delete this product?")) {
            $.ajax({
                url: `http://localhost:5022/api/ProductsControllers/${productId}`,
                type: "DELETE",
                success: function () {
                    showAllCustomer();
                },
                error: function (xhr) {
                    console.log(xhr);
                }
            });
        }
    });
});