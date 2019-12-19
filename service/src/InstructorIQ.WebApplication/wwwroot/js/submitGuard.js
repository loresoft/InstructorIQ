(function ($) {
    $.fn.buttonLoading = function (isLoading = true) {
        return this.each(function () {
            var $this = $(this);
            var method = $this.is('input') ? 'val' : 'html';
            var data = $this.data();
            var d = 'disabled';
            if (typeof data.resetText === 'undefined')
                $this.data('resetText', $this[method]());

            // push to event loop to allow forms to submit
            setTimeout($.proxy(function () {
                if (isLoading === true) {
                    if (data.loadingText)
                        $this[method](data.loadingText);

                    $this.addClass(d).attr(d, d).prop(d, true);
                } else if (isLoading === false) {
                    if (data.resetText)
                        $this[method](data.resetText);

                    $this.removeClass(d).removeAttr(d).prop(d, false);
                }
            }, this), 0);
        });
    };

    $.fn.submitGuard = function () {
        function setSubmittedState($form, isLoading) {
            $form.data('submitted', isLoading);

            var submitSelector = $form.data('submitButton');
            if (!submitSelector)
                submitSelector = ':submit';

            var $button = $(submitSelector);
            if (!$button)
                return;

            $button.buttonLoading(isLoading);
        }

        return this.each(function () {
            var $form = $(this);
            $form.on('submit', function (e) {
                if ($form.data('submitted') === true) {
                    // previously submitted - don't submit again
                    e.preventDefault();
                }
                else if ((typeof $form.valid === 'undefined' || $form.valid())
                    && (typeof this.checkValidity === 'undefined' || this.checkValidity())) {
                    // mark it so that the next submit can be ignored
                    setSubmittedState($form, true);

                    var timeout = $form.data('submitTimeout');
                    var ttl = timeout ? parseFloat(timeout) : 30000;

                    // timeout to allow re-submit if failed
                    setTimeout($.proxy(function () {
                        setSubmittedState($form, false);
                    }, this), ttl);
                }
            });
        });
    };
}(jQuery));
