$(function () {
    $('#menuTree').tree({
        url: "/User/UserIndex/GetModules",
        lines: true,
        animate: true,
        onDblClick: function (node) {
            if(node.attributes.url)
            {
                createTab(node);
            }
        }
    });

    var $tab = $('#contentTab').tabs({
        border: false,
        fit:true,
    });

    $('#contentTab').tabs('add', {
        title: '首页',
        content: '欢迎来到网上下单系统',
        closable: false,
        fit:true,
    });

    //打开菜单对应的页面
    function createTab(node) {
        if ($tab.tabs('exists',node.text)) {
            var ct = $tab.tabs('getSelected');
            if (ct.panel('options').title == node.text) {
                $tab.tabs('update', {
                    tab: ct,
                    options:{
                        content:newFrame(node.attributes.url),
                    }
                }); 
            }
            $tab.tabs('select', node.text);
        }
        else {
            var t= $tab.tabs('add', {
                title: node.text,
                content:newFrame(node.attributes.url),
                closable: true,
                fit: true,
            }); 
        }
    }

    function newFrame(url) {
        var iframe = '<iframe src="' + url + '" style="width:100%;height:100%;border:0px;solid:#000;"></iframe>';
        return iframe;
    }
})