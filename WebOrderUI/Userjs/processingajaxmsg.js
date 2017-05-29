;(function ($) {
    $.extend($, {
         alertMsg:function (msg,title,funcSuc) {
            if($.messager)
            {
                $.messager.alert(title, msg,"info", function () {
                    if (funcSuc) {
                        funcSuc();
                    }
                })
            }
            else {
                alert(title + "\r\n" + msg);
                if (funcSuc) {
                    funcSuc();
                }
            }
         },
         showMsg:function (m,t) {
             if($.messager)
             {
                 $.messager.show({ title: t, msg: m, timeout: 5000, showType: 'slide' });
             }
         },
        procAjaxMsg: function (data,funcSuc,funcErr) {
            if (!data.Statu) {
                return;
            }
            switch (data.Statu) {
                case 1:
                    if (funcSuc) {
                        funcSuc(data)
                    }
                    break;
                case 2:
                    if (funcErr) {
                        funcErr(data);
                    }
                    break;
                case 4:
                    if (data.Msg) {
                        $.alertMsg(data.Msg);
                    }
                    if (window!=top) {
                        top.location.href = data.BackUrl;
                    } else {
                        window.location.href = data.BackUrl;
                    }
                    break;
                case 5:
                    $.alertMsg(data.Msg);
                    break;
            }
        }
    })
})(jQuery);

