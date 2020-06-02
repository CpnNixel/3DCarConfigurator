function checkVisible( elm, eval ) {
    eval = eval || "visible";
    var vpH = window.innerHeight, // Viewport Height
        st = $(window).scrollTop(), // Scroll Top
        y = $(elm).offset().top,
        elementHeight = $(elm).height();
    if (eval == "visible") return ((y < (vpH + st)) && (y > (st - elementHeight)));
    if (eval == "above") return ((y < (vpH + st)));
 }

$(document).ready(() => {
    $(window).scroll(function() {

        $('.animate-block').not('.anim-run').each(function(key, elem){
  
           if(checkVisible($(this))) {
               setTimeout(() => {
                    $(elem).addClass('anim-run');
               }, 500);
           }

           if ($(elem).hasClass('car-description'))
           {
               setTimeout(() => {
                    var count = $('.car-description .description span').length;
                    var timeout = 5;
                    for (let i = 0; i < count; i++)
                    {
                        setTimeout(() => {
                            $('.car-description .description span:nth-of-type('+parseInt(i+1)+')').css({ opacity: 1, transform: 'translateY(0)' });
                            console.log('.car-description .description span:nth-of-type('+parseInt(i+1)+')');
                        }, timeout);
                        timeout += 5;
                    }
                }, 500);
           }
        });
    });
    
    $(document).on('click', () => {
        if ($('.dropdown-content').css('opacity') == '1') { $('.dropdown-content').css('opacity', '0'); }
    })
    $('.dropdown-button').on('click', () => {
        $('.dropdown-content').css('opacity', '1');
    });
    var string = $('.car-description .description').text().split("");
    $('.car-description .description').html('');
    for (var i = 0; i < string.length; i++)
    {
        $('.car-description .description').html($('.car-description .description').html() + (string[i] == ' ' ? '<span class="space">' : '<span>') + string[i] + '</span>');
    }
});