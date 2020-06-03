$(document).ready(() => {
    $(document).on('click', () => {
        if ($('.dropdown-content').css('opacity') == '1') { $('.dropdown-content').css('opacity', '0'); }
    })
    $('.dropdown-button').on('click', () => {
        $('.dropdown-content').css('opacity', '1');
    })
});