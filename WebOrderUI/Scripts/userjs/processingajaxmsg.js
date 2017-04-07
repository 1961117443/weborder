(function ($) {
    $.extend($, {
        procAjaxMsg: function (data,funcSuc,funcErr) {
            if (!data.Statu) {
                return;
            }
            switch (data.Statu) {
                case "ok":
                    if (funcSuc) {
                        funcSuc(data)
                    }
                    break;
                case "err":
                    if (funcErr) {
                        funcErr(data);
                    }
                    break;
            }
        }
    })
})(jQuery);