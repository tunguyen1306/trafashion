$(document).ready(function () {
    var url = window.location.href;
    if (url.indexOf('/Default/ListProducts/')) {

        $('body').removeClass('common-home');
        $('body').addClass('product-category-18');
        $('body').removeClass('product-product-48');

    }
    if (url.indexOf('/Default/Default')) {
        $('body').addClass('common-home');
        $('body').removeClass('product-category-18');
        $('body').removeClass('product-product-48');
    }
    if (url.indexOf('/Default/Detail')) {
        $('body').removeClass('common-home');
        $('body').addClass('product-category-18');
        $('body').removeClass('product-category-18');
    } 
       

    

    //$('#tm-newsletter').submit(function (e) {
    //    e.preventDefault();
    //    var email = $("#input-tm-newsletter-email").val();
    //    var emailRegex = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,4}$/igm;
    //    if (emailRegex.test(email)) {
    //        var dataString = 'tm_newsletter_email=' + email;
    //        $.ajax({
    //            type: "POST",
    //            url: "index.php?route=module/tm_newsletter",
    //            data: dataString,
    //            cache: false,
    //            success: function (result) {
    //                if (!result) {
    //                    $('#tm-newsletter_error').hide();
    //                    $('#tm-newsletter_success').html('You have successfully subscribed').fadeIn(300).delay(4000).fadeOut(300);
    //                } else {
    //                    $('#tm-newsletter_success').hide();
    //                    $('#tm-newsletter_error').html(result).fadeIn(300).delay(4000).fadeOut(300);
    //                }
    //            }
    //        });
    //    } else {
    //        $('#tm-newsletter_error').hide();
    //        $('#tm-newsletter_success').hide();
    //        $('#tm-newsletter_error').html('Please enter a valid e-mail!').fadeIn(300).delay(4000).fadeOut(300);
    //    }
    //});
});

jQuery(document).ready(function () {
    jQuery("#parallax_0>div").cherryFixedParallax({
        invert: false,
    });
});
function getCookie(c_name) {
    var search = c_name + "="
    var returnvalue = "";
    if (document.cookie.length > 0) {
        offset = document.cookie.indexOf(search)
        if (offset != -1) {
            offset += search.length
            end = document.cookie.indexOf(";", offset);
            if (end == -1) end = document.cookie.length;
            returnvalue = unescape(document.cookie.substring(offset, end))
        }
    }
    return returnvalue;
}


//jQuery(document).ready(function ($) {
//    var showIt = getCookie('shownewsletter');
//    var m = 1;
//    var date = new Date();
//    date.setTime(date.getTime() + (m * 60 * 1000));
//    if (showIt == '') {
//        $('#tm-newsletter-popup').fadeIn(300);
//    }
//    $('#newsletter-popup-dont-show').click(function (e) {
//        e.preventDefault()
//        document.cookie = 'shownewsletter=true; path=/; expires=' + date.toString();
//        $('#tm-newsletter-popup').fadeOut(300);
//    })
//    $('#newsletter-popup-close-btn').click(function (e) {
//        e.preventDefault();
//        document.cookie = 'shownewsletter=false';
//        $('#tm-newsletter-popup').fadeOut(300);
//    })
//    $('#tm-newsletter-popup').submit(function (e) {
//        e.preventDefault();
//        var email = $("#input-tm-newsletter-popup-email").val();
//        var emailRegex = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,4}$/igm;
//        if (emailRegex.test(email)) {
//            var dataString = 'tm_newsletter_popup_email=' + email;
//            $.ajax({
//                type: "POST",
//                url: "index.php?route=module/tm_newsletter_popup",
//                data: dataString,
//                cache: false,
//                success: function (result) {
//                    if (!result) {
//                        $('#tm-newsletter-popup_error').hide();
//                        $('#tm-newsletter-popup_success').html('You have successfully subscribed').fadeIn(300).delay(4000).fadeOut(300);
//                    } else {
//                        $('#tm-newsletter-popup_success').hide();
//                        $('#tm-newsletter-popup_error').dequeue();
//                        $('#tm-newsletter-popup_error').html(result).fadeIn(300).delay(4000).fadeOut(300);
//                    }
//                }
//            });
//        } else {
//            $('#tm-newsletter-popup_error').hide();
//            $('#tm-newsletter-popup_success').hide();
//            $('#tm-newsletter-popup_error').html('Please enter a valid e-mail!').fadeIn(300).delay(4000).fadeOut(300);
//        }
//    });


//});



jQuery(function () {
    jQuery('#camera_wrap_0').camera({
        navigation: true,
        playPause: false,
        thumbnails: false,
        navigationHover: false,
        barPosition: 'top',
        loader: false,
        time: 3000,
        transPeriod: 800,
        alignment: 'center',
        autoAdvance: true,
        mobileAutoAdvance: true,
        barDirection: 'leftToRight',
        barPosition: 'bottom',
        easing: 'easeInOutExpo',
        fx: 'simpleFade',
        height: '55.3125%',
        minHeight: '300px',
        hover: true,
        pagination: false,
        loaderColor: '#1f1f1f',
        loaderBgColor: 'transparent',
        loaderOpacity: 1,
        loaderPadding: 0,
        loaderStroke: 3,
    });
});
