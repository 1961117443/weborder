var loginDialog;
var loginInputForm;
$(function () {
    InitData();
    var formParam = {
        url: '/AdminLogin/LoginIn',
        success: onLogin,
    }
    loginDialog=$("#loginDialog").dialog({
        title: "用户登录",
        width: 380,
        height: 230,
        modal: true,
        closable: false,
        buttons: [
            {
                text: "注册",
                iconCls: 'icon-edit',
                handler: function () {

                }
            }, {
                text: "登录",
                iconCls: 'icon-ok',
                handler: function () {
                    $('#loginInputForm').submit();
                }
            }]
    });

    loginInputForm = $('#loginInputForm').form(formParam);

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

function InitData() {
    $('#userName').attr('value', 'admin');
    $('#passWord').attr('value', 'admin');
   // $('#code').focus();
}

//刷新验证码
function RefershValidateCode() {
    var url = $("#imgCode").attr("src");
    $("#imgCode").attr("src", url + 1);
};


 /*ajax登录成功后调用的方法 */ 
function onLogin(jsonData) {
    jsonData = $.parseJSON(jsonData);
    $.procAjaxMsg(jsonData, function () { 
        loginDialog.dialog("close"); 
        window.location = jsonData.BackUrl; 
    }, function () {
        $.alertMsg(jsonData.Msg, "提示", null); 
    });
};
    