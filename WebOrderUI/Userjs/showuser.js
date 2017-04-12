$(function () {
    var datagrid;
    datagrid=$('#datagrid').datagrid({
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
            { field: 'LoginTime', title: '最后登录时间', width: 140, align:center, formatter:formatDatebox,editor:'datebox'   }
        ]
        ],
     });

     function clearSearch() {
         datagrid.datagrid('load', {});
         $('#searchForm input').val('');
     }
    /*
var datagrid;
    $.ajax({
        url: '/Admin/ShowUsers',
        type: 'post',
        datatype: 'json',
        success: function (data) {
            datagrid = $('#datagrid');
            datagrid.datagrid({
                columns: [data.title],
            });
           // datagrid.datagrid('loadData', data.rows); 
        }
    })
    */
})