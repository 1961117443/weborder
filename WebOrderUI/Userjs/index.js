
/*从cookie中读取保存的主题信息*/
function initTheme() {
    var cookie_skin = $.cookie('easyuiThemeName');
    if (cookie_skin) {
        var $easyuiTheme = $('#easyuiTheme');
        $easyuiTheme.attr('href', cookie_skin);
    }
};

$(function () {
    initTheme();
    
    $('#menuTree').tree({
        url: "/User/UserIndex/GetModules",
        lines: true,
        animate: true,
        onDblClick: function (node) {
            if (node.attributes.url) {
                createTab(node);
            }
        }
    });

    var $tab = $('#contentTab').tabs({
        border: false,
        fit: true,
        onContextMenu: function (e, title, index) {
            e.preventDefault();
            $('#tabMenu').menu('show', {
                left: e.pageX,
                top: e.pageY,
            }).data("tabTitle",title);
        }
    });

    $('#contentTab').tabs('add', {
        title: '首页',
        content: xz.newFrame('/User/UserIndex/TabIndex') ,
        closable: false,
        fit: true,
    });
    
    function dealWithTabMenu(menu, type) {
        var tab = $tab.tabs('getSelected');
        var menuTitle = $(menu).data('tabTitle');
    };


    $('#tabMenu').menu({
        onClick: function (item) {
            dealWithTabMenu(this, item.name);
        }
    });
     

    //打开菜单对应的页面
    function createTab(node) {
        if ($tab.tabs('exists', node.text)) {
            var ct = $tab.tabs('getSelected');
            if (ct.panel('options').title == node.text) {
                $tab.tabs('update', {
                    tab: ct,
                    options: {
                        content: xz.newFrame(node.attributes.url),
                    }
                });
            }
            $tab.tabs('select', node.text);
        }
        else {
            var t = $tab.tabs('add', {
                title: node.text,
                content: xz.newFrame(node.attributes.url),
                closable: true,
                fit: true,
            });
        }
    }
    /*
    function newFrame(url) {
        var iframe = '<iframe id="iframe" src="' + url + '" style="width:100%;height:100%;border:0px;solid:#000;"></iframe>';
        return iframe;
    }
    */

    /*退出按钮*/
    $('#loginOut').linkbutton({
        iconCls: 'icon-exit',
        onClick: function () {
            $.messager.confirm("请确认", "您确认要退出登录吗？", function (r) {
                if (r) {
                    $.ajax({
                        type: 'POST',
                        url: '/AdminLogin/LoginOut',
                        success: function (jsonData) {
                            $.procAjaxMsg(jsonData, function () { 
                                window.location = jsonData.BackUrl;
                            }, function () {
                                $.alertMsg(jsonData.Msg, "提示", null);
                            });
                        }
                    })
                }
            }) 
        }
    }) 

    /*修改用户登录密码*/
    $('#loginUser').linkbutton({
        iconCls: 'icon-people',
        onClick: function () {
            showModifyUserForm(); 
        }
    })
});

/*利用封装的方法把修改密码的对话框显示出来*/
function showModifyUserForm() { 
    var p = xz.dialog({
        title: '修改密码',
        width: 280,
        height: 200,
        closed: false,
        href: '/User/UserIndex/ModifyUserForm',
        iconCls: 'icon-save',
        buttons: [{
            iconCls:'icon-ok',
            text: '确定',
            handler: function () {
                alert('确定');
            }
        }, {
            iconCls:'icon-cancel',
            text: '取消',
            handler: function () {
                p.window('close');
            }
        }]
    });
   
}
