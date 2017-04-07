$(function () {
    $('#login').dialog({
        title: '用户登录',
        width: 300,
        heigth: 180, 
        modal: true,
        closable: false,
        buttons: [
            {
                text: '登录', 
                handler: function () {
                    console.info("用户名：" + $('#userName').val() + ",密码:" + $('#passWord').val())
                    $.ajax({
                        type: 'POST',
                        url: '/Admin/LoginIn',
                        data: {
                            name: $('#userName').val(),
                            pwd: $('#passWord').val()
                        },
                        cache: false,
                        dataType: 'json',
                        success: ok,
                    });

                },
                iconCls: 'icon-ok',
            }
        ],
    });

    $('#userName').validatebox({
        required: true,
        missingMessage: '请输入用户帐号',
        invalidMessage:'用户帐号不能为空',
    });

    
    $('#passWord').validatebox({
        required: true,
        missingMessage: '请输入用户密码',
        invalidMessage: '用户密码不能为空',
    });

    function ok(jsonData) {
        $.procAjaxMsg(jsonData, function () {
            window.location = jsonData.BackUrl;
        }, function () {
            alert("登录失败！");
        });
    };
    /*
    //登录按钮
    $('#btn a').click(function () {
        if (!$('#userName').validatebox('isValid')) {
            $('#userName').focus();
        } else if (!$('#passWord').validatebox('isValid')) {
            $('#passWord').focus();
        } else {
            //服务器提交
            alert('123');
        }
    });
    */
})