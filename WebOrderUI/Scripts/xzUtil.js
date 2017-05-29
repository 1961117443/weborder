/*
定义全局对象，类似于命名空间的作用 */
var xz = $.extend({}, xz);

/*
** 取消easyui默认开启的parser
** 在页面加载之前，先开启一个进度条
** 然后在页面所有easyui组件渲染完毕后，关闭进度条
**
*/
$.parser.auto = false;
$(function () {
    $.messager.progress({
        text: "页面加载中。。。。",
        interval: 100
    });
    $.parser.parse(window.document);
    window.setTimeout(function () {
        $.messager.progress('close');
        if (self != parent) {
            window.setTimeout(function () {
                try {
                    parent.$.messager.progress('close');
                } catch (e) {

                }
            }, 500);
        }
    }, 1);
    $.parser.auto = true;
});

/*
**
** 更换easyui皮肤的方法
**
*/
xz.changeTheme = function (themeName) {
    var $easyuiTheme = $('#easyuiTheme');
    var url = $easyuiTheme.attr('href');
    var href = url.substring(0, url.indexOf('themes')) + 'themes/' + themeName + '/easyui.css';
    $easyuiTheme.attr('href', href);
    /*进一步调整iframe内嵌框架的样式*/
    var $iframe = $('iframe');
    var $div = $('div');
    console.info($div.length);
    console.info($iframe.length);
    if ($iframe.length>0) {
        for (var i = 0; i < $iframe.length; i++) {
            var ifr = $iframe[i];
            $(ifr).contents().find("$easyuiTheme").attr('href', href);
        }
    }
    /*用cookie保存主题*/
    $.cookie('easyuiThemeName', href, {
        path: '/',
        expires: 7
    });
};


/*
**把一个div以easyui对话框的形式显示出来
*/
xz.dialog = function (options) {
    var opts = $.extend({
        modal: true,
        onClose: function () { 
            $(this).dialog('destroy');
        }
    }, options);
    //console.info(window.parent.$('<div/>'));
    return $('<div/>').dialog(opts);
};

xz.window = function (options) {
    var opts = $.extend({
        modal: true,
        collapsible: false,
        minimizable: false,
    }, options);
    return $('<div/>').window(opts);
}

xz.newFrame = function (url) {
    var iframe = '<iframe id="iframe" src="' + url + '" style="width:100%;height:100%;border:0px;solid:#000;"></iframe>';
    return iframe;
}; 