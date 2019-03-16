(function ($) {

    $.fn.copyValue = function () {

        this.blur(function () {
            var currentValue = this.value;
            if (!currentValue)
                return;

            var target = $(this).data('target');
            var $target = $(target);

            var targetValue = $target.val();
            if (targetValue)
                return;

            $target.val(currentValue);
        });

        return this;
    };

}(jQuery));