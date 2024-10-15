$(document).ready(function () {
    $("#CreateButton").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "http://localhost:5022/api/ProductsControllers",
            type: "post",
            contentType: "application/json",
            data: JSON.stringify({
                ProductName: $("#ProductName").val(),
                CategoryId: $("#CategoryId").val(),
                UnitsInStock: $("#UnitsInStock").val(),
                UnitPrice: $("#UnitPrice").val(),
            }),
            success: function (result) {
                window.location.href = "/Product/Index";s
            },
            error: function (xhr) {
                console.log(xhr);
            },
        });
    });
});