


$(function () {
    var detailGrid;
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
    /*首页订单列表*/
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

    
    /*订单明细*/
    detailGrid=$('#detaildatagrid').datagrid({
        fitColumns: true, 
        title: "订单明细",
        iconCls: "icon-save",
        fit: true,
       // pagination: true,
        pagePosition: "bottom",
        checkOnSelect: false,
        selectOnCheck: false,
        pageList: [100],
        pageSize: 100,
        rownumbers:true,
        columns: [[
            { field: 'ID', checkbox: true },
            { field: 'action', title: '操作', width: 80, align: 'center', formatter: formatAction },
            { field: 'DNo', title: '订单跟踪号', width: 80 },
            {
                field: 'SectionbarID', title: '型材型号', width: 80,
                formatter: function (value, row) {
                    return row.SectionbarCode;
                },
                editor: {
                    type: 'combogrid',
                    options: { 
                        panelWidth: 400,
                        valueField: 'SectionbarID',
                        textField: 'SectionbarCode',
                        method: 'get',
                        url: '/BasicData/Sectionbar/GetSectionbar',
                        pagination: true,
                        pagePosition: "bottom",
                        columns: [[
                            { field: 'ID', title: '型号ID', hidden:true},
                            { field: 'Code', title: '型材型号', width: 120 },
                            { field: 'Name', title: '型材名称', width: 120 },
                        ]],
                        onClickRow: function (i, r) {
                           // var row = detailGrid.datagrid('getSelected');

                            if (editIndex != undefined) {
                                detailGrid.datagrid('updateRow', {
                                    index: editIndex,
                                    row: {
                                        SectionbarID: r.ID,
                                        SectionbarCode: r.Code,
                                        SectionbarName: r.Name,
                                    }
                                })
                            }

                        }
                    }
                }
            }, 
            { field: 'SectionbarName', title: '型材名称', width: 80 },
            { field: 'Quantity', title: '数量', width: 80, editor: 'numberbox' },
            { field: 'Remark', title: '备注', width: 100, editor: 'textarea' }
        ]],
        toolbar: [{
            text: '增行',
            iconCls: 'icon-add',
            handler: append,
        }, {
            text: '修改',
            iconCls: 'icon-edit',
            handler: EditOrder,
        }, {
            text: '删除',
            iconCls: 'icon-remove',
            handler: delRow,
        }],
        onClickRow:onClickRow,
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
     

    /*客户下拉列表*/
    $('#CustomerID').combogrid({
        delay: 500,
        mode: 'remote',
        url: '/BasicData/Customer/ShowCustomer',
        idField: 'ID',
        textField: 'Name',
        panelWidth:240,
        columns: [[
            { field: 'Code', title: '客户编号', width: 120 },
            { field: 'Name', title: '客户名称', width: 120 },
        ]],
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
        ShowDetail({ title: '新增订单', ID:0,State:1 }); 
    };
    /*修改订单*/
    function EditOrder() {
        var row = datagrid.datagrid('getSelected');
        if (row) {
            ShowDetail({ title: '修改订单--[' + row.BillCode + ']', ID: row.ID, State: 1 });
        }  
    };

    /*打开订单明细的参数*/
    formParam = {
        title: "",
        ID: 0,
        State:0,
    }
    /*显示订单明细*/
    function ShowDetail(param) {
        var mainUrl = '/Order/OrderIndex/GetOrder/' + param.ID;
        var detailUrl='/Order/OrderIndex/GetOrderDetail/' + param.ID;

        var win = $('#detailWindow').window({
            title: param.title,
            modal: true,
            resizable: false,
            minimizable: false,
            maximizable: false,
            draggable: false, 
        });
        $.ajax({
            type: 'post',
            url: mainUrl,
            success: function (data) {
                if (data) {
                    $.each($("input"), function (a, b) {
                        var N = $(b).attr("id");
                        /*有这个控件*/
                        if (N != undefined) {
                            /*json对象有这个属性*/
                            var V = data[N];
                            if (V != undefined) {
                                V = V + "";
                                if (V.indexOf('Date') > 0) {
                                    $('#' + N).textbox('setText', formatDatebox(V));
                                }
                                else {
                                    $('#' + N).textbox('setText', V);
                                }
                            }
                            if (param.State==0) {
                                $('#' + N).textbox('readonly');
                            }
                        }
                    });  
                    $('#detaildatagrid').datagrid({
                        url: detailUrl,
                    })
                }
            }
        });
        win.window('open').window('maximize');
    }

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

    /*订单明细操作*/
    var editIndex = undefined;
    function endEditing() {
        if (editIndex == undefined) {
            return true;
        }
        if (detailGrid.datagrid('validateRow', editIndex)) {
            var ed = detailGrid.datagrid('getEditor', { index: editIndex, field: 'Quantity' });
            detailGrid.datagrid('endEdit', editIndex);
            editIndex = undefined;
            return true;
        } else {
            return false;
        }
    };
    function onClickRow(index) {
        if (editIndex != index)
        {
            if (endEditing()) {
                detailGrid.datagrid('selectRow', index).datagrid('beginEdit', index);
                editIndex = index;
            }
            else {
                detailGrid.datagrid('selectRow', editIndex);
            }
        }
    }
    /*增行*/
    function append() {
        if (endEditing()) { 
            detailGrid.datagrid('appendRow', {});
            editIndex = detailGrid.datagrid('getRows').length - 1;
            detailGrid.datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
        }
       
    };
    /*删行*/
    function delRow() {
        if (editIndex==undefined) {
            return
        }
        detailGrid.datagrid('cancelEdit', editIndex).datagrid('deleteRow', editIndex);
        editIndex = undefined; 
    };

    function accept() {
        if (endEditing()) {
            detailGrid.datagrid('acceptChanges');
            editIndex = undefined;
        }
    }
}); 