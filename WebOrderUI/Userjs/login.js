var loginDialog, loginTabs, loginForm;

$(function () {
    /*表单提交的参数对象*/
    var formParam = {
        url: '/AdminLogin/LoginIn',
        success: dealWithLogin,
    }

    /*把表单参数对象和表单元素结合起来*/
    loginForm = $('#loginInputForm').form(formParam);
    /*登录窗体*/
  loginDialog= $("#loginDialog").dialog({
        title: "用户登录",
        width: 350,
        height: 210,
        modal: true,
        closable: false,
        buttons: [
            {
                text: "注册",
                handler: function () {

                }
            }, {
                text: "登录",
                handler: function () {
                    loginForm.submit(); 
                }
            }]
  });

    $("#validateType").combobox({
        valueField: 'id',
        textField: 'text',
        data: [
            {
            id: 1,
            text: "普通用户"
        }, {
            id: 2,
            text: "ERP用户"
        }]
    });

    $("#loginTabs").tabs({
        fit: true,
        border: false,
        narrow: true,
    });

    
});

//刷新验证码
function RefershValidateCode() {
    var url = $("#imgCode").attr("src");
    $("#imgCode").attr("src", url + 1);
}

/*ajax提交成功以后调用的方法*/
function dealWithLogin(jsonData) {
    if (jsonData) {
        //把json字符串转化为json对象
        jsonData = $.parseJSON(jsonData);
        $.procAjaxMsg(jsonData, function () {
            loginDialog.dialog('closed');
            window.location = jsonData.BackUrl;
        }, function () {
            $.alertMsg(jsonData.Msg, '登录失败', null);
        })
    }
    
}

/*
 
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
                            url: '/AdminLogin/LoginIn',
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
    /*
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
    */