const $nav = $('li[data-toggle="collapse"]');
$nav.click(function () {
    $(this).toggleClass("nav-active");
});

function OpenModalEditCustomer(id) {
    $("#editCustomerManager").load("Customers/Edit?id=" + id, function () {
        $("#editCustomerManager").modal();
    });
}

$(".maskMoney").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });