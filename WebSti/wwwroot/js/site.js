
$(document).ready(function () {
    $('.multiple-items').slick({
        dots: false,
        arrows: true,
        slidesToShow: 5,
        slidesToScroll: 1,
        responsive: [
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 1,
                    centerMode: false, /* set centerMode to false to show complete slide instead of 3 */
                    slidesToScroll: 1
                }
            }
        ],
        prevArrow: "<i class='bi bi-arrow-left' style='font-size: 2rem'></i>",
        nextArrow: "<i class='bi bi-arrow-right' style='font-size: 2rem'></i>"
    });
});

$('.active-filter').on('click', function (e) {
    $("div").removeClass('draw-border');
    $(this).toggleClass('draw-border');  
});

var today = new Date();

$(function () {
    $('#datepicker').daterangepicker({
        startDate: new Date(today.getFullYear(), 0, 1),
        endDate: today,
        locale: {
            format: 'DD.MM.YYYY',
            "applyLabel": "Ок",
            "cancelLabel": "Отмена",
            "fromLabel": "От",
            "toLabel": "До",
            "customRangeLabel": "Произвольный",
            "daysOfWeek": [
                "Вс",
                "Пн",
                "Вт",
                "Ср",
                "Чт",
                "Пт",
                "Сб"
            ],
            "monthNames": [
                "Январь",
                "Февраль",
                "Март",
                "Апрель",
                "Май",
                "Июнь",
                "Июль",
                "Август",
                "Сентябрь",
                "Октябрь",
                "Ноябрь",
                "Декабрь"
            ],
            firstDay: 1
        },

    });
});