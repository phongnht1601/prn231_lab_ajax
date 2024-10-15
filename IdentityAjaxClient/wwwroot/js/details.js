$(document).ready(function () {
    $("#GetButton").click(function (e) {
        $(".table tbody").html("");

        $.ajax({
            url: "http://localhost:5022/api/ProductsControllers/" + $("#Id").val(),
            type: "get",
            contentType: "application/json",
            success: function (result, status, xhr) {
                $("#resultDiv").show();
                if (typeof result !== "undefined") {
                    var str = `<tr>
                               <td>${result["productId"]}</td>
                               <td>${result["productName"]}</td>
                               <td>${result["categoryId"]}</td>
                               <td>${result["unitsInStock"]}</td>
                               <td>${result["unitPrice"]}</td>
                           </tr>`;
                    $("table tbody").append(str);
                } else {
                    $("table tbody").append('<td colspan="4">No Product</td>');
                }
            },
            error: function (xhr, status, error) {
                console.log(xhr);
            },
        });
    });
});