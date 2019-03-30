const $nav = $('li[data-toggle="collapse"]');
$nav.click(function () {
    $(this).toggleClass("nav-active");
});
