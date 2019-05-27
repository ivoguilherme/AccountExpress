const $nav = $('li[data-toggle="collapse"]');
$nav.click(function () {
    $(this).toggleClass("nav-active");
});

$(document).ready(function () {

    $(".maskMoney").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });



});