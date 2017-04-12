$(function () {
    var datagrid;
    datagrid = $('#datagrid').datagrid({
        fitColumns:true,
        url: "/Admin/ShowUsers",
        title: "用户列表",
        iconCls: "icon-save",
        fit:true,
        pagination: true,
        pagePosition: "bottom",
        pageSize: 1, 
        pageList:[1,2,3,4,5],
        columns: [[
            { field: 'ID', checkbox: true },
            { field: 'UserName', title: '用户名', width: 80 },
            { field: 'LoginTime', title: '最后登录时间', width: 140, formatter:formatDatebox,editor:'datebox'   }
        ]],
    });

    serializeObject = function (form) {
        var o = [];
        $.each(form.serializeArray(), function (index) {
            if (o[this["name"]]) {
                o[this["name"]] = o[this["name"]] + "," + this["value"];
            } else {
                o[this["name"]] = this["value"];
            }
        });
        return o;
    };
    function _search() {
        datagrid.datagrid('load', serializeObject($('#searchForm')));
    }

     function clearSearch() {
         datagrid.datagrid('load', {});
         $('#searchForm input').val('');
     }

})