


$(function () {

    function formatAction(value, row, index) {
        if (row.editing) {
            var s = '<a href="#" onclick="saverow(this)">保存</a> ';
            var c = '<a href="#" onclick="cancelrow(this)">取消</a>';
            return s + c;
        } else {
            var v = '<a href="#" onclick="viewpic(this)">简图</a> ';
            var e = '<a href="#" onclick="editrow(this)">修改</a> ';
            var d = '<a href="#" onclick="deleterow(this)">删除</a>';
            return v;//+ e + d;
        }
    };

    var datagrid; 

    var $win;
    $win = $('#test-window').window({
        title: '添加课程设置信息',
        width: 820,
        height: 450,
        top: ($(window).height() - 820) * 0.5,
        left: ($(window).width() - 450) * 0.5,
        shadow: true,
        modal: true,
        iconCls: 'icon-add',
        closed: true,
        minimizable: false,
        maximizable: false,
        collapsible: false
    });

    

    datagrid = $('#datagrid').datagrid({
        fitColumns: true,
        url: "/Order/OrderIndex/ShowOrders",
        title: "订单列表",
        iconCls: "icon-save",
        fit: true,
        pagination: true,
        pagePosition: "bottom",
        checkOnSelect: false,
        selectOnCheck: false,
        columns: [[
            { field: 'ID', checkbox: true },
          //   { field: 'action', title: '操作', width: 80, align: 'center', formatter: formatAction },
            { field: 'BillCode', title: '订单号', width: 80 },
            { field: 'OrderDate', title: '订单日期', width: 140, formatter: formatDatebox, editor: 'datebox' },
            { field: 'CustName', title: '客户名称', width: 80 },
            { field: 'Remark', title: '备注', width: 100 }
        ]],
        toolbar: [{
            text: '新增',
            iconCls: 'icon-add',
            handler: AddOrder,
        }, {
            text: '修改',
            iconCls: 'icon-edit',
            handler: EditOrder,
        }, {
            text: '删除',
            iconCls: 'icon-remove',
            handler: DeleteOrder,
        }],
    });

    
    
    $('#detaildatagrid').datagrid({
        fitColumns: true, 
        title: "订单列表",
        iconCls: "icon-save",
        fit: true,
        pagination: true,
        pagePosition: "bottom",
        checkOnSelect: false,
        selectOnCheck: false,
        pageList:[100],
        columns: [[
            { field: 'ID', checkbox: true },
           { field: 'action', title: '操作', width: 80, align: 'center', formatter: formatAction },
            { field: 'BillCode', title: '订单号', width: 80 },
            { field: 'OrderDate', title: '订单日期', width: 140, formatter: formatDatebox, editor: 'datebox' },
            { field: 'CustName', title: '客户名称', width: 80 },
            { field: 'Remark', title: '备注', width: 100 }
        ]],
        toolbar: [{
            text: '增行',
            iconCls: 'icon-add',
            handler: AddOrder,
        }, {
            text: '修改',
            iconCls: 'icon-edit',
            handler: EditOrder,
        }, {
            text: '删除',
            iconCls: 'icon-remove',
            handler: DeleteOrder,
        }],
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

    $('#btnQuery').linkbutton({
        iconCls: 'icon-search',
        onClick: _search,
    });

    $('#btnCancel').linkbutton({
        iconCls: 'icon-undo',
        onClick: clearSearch,
    });

    $('#btnOk').linkbutton({
        iconCls: 'icon-ok',
        onClick: function () {

        },
    });

    $('#btnCancel').linkbutton({
        iconCls: 'icon-ok',
        onClick: function () {
            detailWindow.window('close');
        },
    });

    $('#gender').combobox({
        url: '~/Content/jsonData/genders.json',
        valueField: 'id',
        textField:'text',
    });

    function _search() {
        datagrid.datagrid('load', serializeObject($('#searchForm')));
    };

    function clearSearch() {
        // console.info("1");
        $('#datagrid').datagrid('load', {});
        $('#searchForm input').val("");
    };

    /*添加订单*/ 
    function AddOrder() { 
       var win= $('#detailWindow').window({
            width: 800,
            height: 550,
            modal: true,
            resizable: false,
            minimizable: false,
            maximizable: false,
            draggable:true,
            tools: [{
                text: '保存',
                iconCls: 'icon-save',
                handler: function () { 
                    $(this).window('close');
                },
            }
            ] 
        });
       $.ajax({
           type: 'post',
           url: '/Order/OrderIndex/GetOrder',
           success: function (data) { 
               if (data) {
                   if (data) {
                       $.each(data, function (N, V) { 
                           if (V.indexOf('Date')>0) { 
                               $('#' + N).textbox('setText', formatDatebox(V));
                           }
                           else
                           {
                               $('#' + N).textbox('setText', V);
                           }
                           console.info($('#' + N).textbox('getText'));
                       });
                       var id = -1;
                       if (data.ID) {
                           id = data.ID;
                       }      
                       $('#detaildatagrid').datagrid({ 
                           url: '/Order/OrderIndex/GetOrderDetail?ID='+id,
                       })
                   };
                    
               } 
           }
       });

       win.window('open').window('maximize');
    };
    /*修改订单*/
    function EditOrder() {
        var row = datagrid.datagrid('getSelected');
        if (row) {
            var win = $('#detailWindow').window({
                title: '修改订单--[' + row.BillCode + ']',
                width: 800,
                height: 550,
                modal: true,
                resizable: false,
                minimizable: false,
                maximizable: false,
                draggable: true,
                tools: [{
                    text: '保存',
                    iconCls: 'icon-save',
                    handler: function () {
                        $(this).window('close');
                    },
                }
                ]
            });
            $.ajax({
                type: 'post',
                url: '/Order/OrderIndex/GetOrder?ID=' + row.ID,
                success: function (data) { 
                    
                    if (data) {
                        $.each($("input"), function (a,b) {
                            var N = $(b).attr("id");
                            /*有这个控件*/
                            if (N != undefined) {
                                /*json对象有这个属性*/
                                var V = data[N];
                                if (V != undefined) {
                                    V = V + "";
                                    if (V.indexOf('Date') > 0) {
                                        $('#' + N).textbox('setText', formatDatebox(V)).textbox('readonly');
                                    }
                                    else {
                                        $('#' + N).textbox('setText', V).textbox('readonly');
                                    }
                                } 
                            }
                        });
                        /*
                        if (data) { 
                            $.each(data, function (N, V) {
                                V = V + "";
                                if (V.indexOf('Date') > 0) {
                                    $('#' + N).textbox('setText', formatDatebox(V)).textbox('readonly');
                                }
                                else {
                                    $('#' + N).textbox('setText', V).textbox('readonly');
                                } 
                            });
                            var id = -1;
                            if (data.ID) {
                                id = data.ID;
                            }
                            $('#detaildatagrid').datagrid({
                                url: '/Order/OrderIndex/GetOrderDetail?ID=' + id,
                            })
                        };
                        */
                    }
                }
            }); 
            win.window('open').window('maximize');
        }  
    };
    /*删除订单*/
    function DeleteOrder() {
        var rows = datagrid.datagrid('getChecked');
        if (rows.length > 0) {
            $.messager.confirm("请确认", "确认要删除选中的" + rows.length + "份订单吗？", function (r) {
                if (r) {
                    var ids = "";
                    for (var i = 0; i < rows.length; i++) {
                        ids = ids + "," + rows[i].ID;
                    }
                    $.ajax({
                        type: 'post',
                        url: '/Order/OrderIndex/DeleteOrder?ids=' + ids,
                        success: function (data) {
                            $.procAjaxMsg(data, function () {
                                $.alertMsg(data.Msg);
                                datagrid.datagrid('reload');
                            })
                        }
                    })
                }
            })
        }
    };
  //  detailWindow.window('close');
});



function showOrderDetail(param) {
    //var w = xz.window({
    //    width: 800,
    //    height: 600,
    //    title:param.title,
    //});
    //console.info(w);
    //w.window('refresh', param.url);
    //w.window('open'); 
    var p = xz.dialog({
        title: param.title,
        width: 800,
        height: 600,
        closed: false,
        iconCls:'icon-save',
        href: param.url, 
        buttons: [{
            iconCls: 'icon-ok',
            text: '确定',
            handler: function () {
                //    var f = p.find('<form>');
                var f = $('<form method="post"></form>');
                var g = $('#grid');
                if (f) {
                    f.submit();
                } 
                if (g) {
                    rows = g.datagrid('getRows');
                    console.info(rows.length);
                } 
                p.window('close');
                
            }
        }, {
            iconCls: 'icon-cancel',
            text: '取消',
            handler: function () { 
                p.window('close');
            }
        }]
    })
}

