$(function () {
    datagrid = $('#datagrid').datagrid({
        url: "",
        title: "用户列表",
        iconCls: "icon-save",
        fit:true,
        pagination: true,
        pagePosition: "buttom",
        pageSize:10,
    });
})