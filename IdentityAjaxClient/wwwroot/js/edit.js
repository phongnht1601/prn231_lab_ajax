$(document).ready(function () {
    getProduct();

    function getProduct() {
        let params = new URL(document.location).searchParams;
        let productId = params.get("id");

        $.ajax({
            url: "http://localhost:5022/api/ProductsControllers/" + productId,
            type: "get",
            contentType: "application/json",
            success: function (result, status, xhr) {
                $("#ProductId").val(result["productId"]);
                $("#ProductName").val(result["productName"]);
                $("#CategoryId").val(result["categoryId"]);
                $("#UnitsInStock").val(result["unitsInStock"]);
                $("#UnitPrice").val(result["unitPrice"]);
            },
            error: function (xhr, status, error) {
                console.log(xhr);
            },
        });
    }

    $("#UpdateButton").click(function (e) {
        e.preventDefault();
        let productId = $("#ProductId").val();
        $.ajax({
            url: "http://localhost:5022/api/ProductsControllers/" + productId,
            type: "put",
            data: JSON.stringify({
                ProductId: productId,
                ProductName: $("#ProductName").val(),
                CategoryId: $("#CategoryId").val(),
                UnitsInStock: $("#UnitsInStock").val(),
                UnitPrice: $("#UnitPrice").val(),
            }),
            processData: false,
            contentType: "application/json",

            success: function (result, status, xhr) {
                var str = `<tr>
                               <td>${result["productId"]}</td>
                               <td>${result["productName"]}</td>
                               <td>${result["categoryId"]}</td>
                               <td>${result["unitsInStock"]}</td>
                               <td>${result["unitPrice"]}</td>
                           </tr>`;
                $("table tbody").append(str);
                $("#resultDiv").show();
            },
            error: function (xhr, status, error) {
                console.log(xhr);
            },
        });
    });
});