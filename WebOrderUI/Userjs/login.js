$(function () {
    var login;
    login=$('#login').dialog({
        title: '用户登录',
        width: 300,
        heigth: 180,
        top:50,
        modal: true,
        closable: false,
        buttons: [
            {
                text: '登录', 
                handler: function () {
                    if (!$('#userName').validatebox('isValid')) {
                        $('#userName').focus();
                    } else if (!$('#passWord').validatebox('isValid')) {
                        $('#passWord').focus();
                    } else {
                        //服务器提交 
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
                    } 
                },
                iconCls: 'icon-ok',
                id:'btnlogin'
            }
        ],
    });

    $('#loginForm').form({
        
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

    /*ajax成功后调用的方法 */
    function ok(jsonData) {
        $.procAjaxMsg(jsonData, function () {
            //login.dialog("close");
            window.location = jsonData.BackUrl;
            console.info(jsonData);
        }, function () {
             $.alertMsg(jsonData.Msg,"提示",null);
           // $.showMsg(jsonData.Msg, "提示");
        });
    };
    
})