(function ($) {

    $.fn.copyDate = function (options) {

        var settings = $.extend({}, $.fn.copyDate.defaults, options);

        function parseNumber(numberText, defaultValue) {
            var value = parseFloat(numberText);
            return value ? value : defaultValue;
        }

        this.blur(function () {
            if (!this.value)
                return;

            var target = $(this).data('target');
            var $target = $(target);

            var current = $target.val();
            if (current)
                return;

            var dateValue = moment(this.value);

            var hours = parseNumber(
                $(this).data('hours'),
                settings.hours);

            if (hours)
                dateValue = dateValue.add(hours, 'h');

            var minutes = parseNumber(
                $(this).data('minutes'),
                settings.minutes);

            if (minutes)
                dateValue = dateValue.add(minutes, 'm');

            var seconds = parseNumber(
                $(this).data('seconds'),
                settings.seconds);

            if (seconds)
                dateValue = dateValue.add(seconds, 's');

            var targetValue = dateValue.format('YYYY-MM-DDTHH:mm');
            $target.val(targetValue);
        });

        return this;
    };

    $.fn.copyDate.defaults = {
        hours: 3,
        minutes: 0,
        seconds: 0
    };

}(jQuery));