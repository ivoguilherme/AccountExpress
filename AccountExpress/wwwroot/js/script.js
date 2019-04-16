const $nav = $('li[data-toggle="collapse"]');
$nav.click(function () {
    $(this).toggleClass("nav-active");
});

$(document).ready(function () {
    $('#dtBasicExample').DataTable();
    $('.dataTables_length').addClass('bs-select');
});
