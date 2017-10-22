var detailGrid;
var detailWindow;
var datagrid; 

$(function () {


    function formatAction(value, row, index) {
        if (row.editing) {
            var s = '<a href="#" onclick="saverow(this) ">保存</a> ';
            var c = '<a href="#" onclick="cancelrow(this)">取消</a>';
            return s + c;
        } else {
            var v = '<a href="#" onclick="viewpic(this)">简图</a> ';
            var e = '<a href="#" onclick="editrow(this)">修改</a> ';
            var d = '<a href="#" onclick="deleterow(this)">删除</a>';
            return v;//+ e + d;
        }
    };
  
    /*首页订单列表*/
    datagrid = $('#datagrid').datagrid({
        //fitColumns: true,
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
            {
                field: 'action', title: '操作', width: 100, align: 'center',
                formatter: function (v,r,i) {
                    var v = '<a href="#" onclick="viewrow(this)" rowID=' + r.ID + ' rowIndex=' + i + ' BillCode=' + r.BillCode + '>查看</a> ';
                    var e = '<a href="#" onclick="editrow(this)" rowID=' + r.ID + ' rowIndex=' + i + ' BillCode=' + r.BillCode + '>修改</a> ';
                    var d = '<a href="#" onclick="deleterow(this)" rowID=' + r.ID + ' rowIndex=' + i + ' BillCode=' + r.BillCode + '>删除</a>';
                    return v + e + d;
                }
            },
            { field: 'BillCode', title: '订单号', width: 80 },
            { field: 'OrderDate', title: '订单日期', width: 140, formatter: formatDatebox, editor: 'datebox' },
            { field: 'CustName', title: '客户名称', width: 80 },
            { field: 'Remark', title: '备注', width: 100 }
        ]],
        toolbar: [{
            text: '新增',
            iconCls: 'icon-add',
            handler: AddOrder,
        },{
            text:'|',
        },
        //{
        //    text: '修改',
        //    iconCls: 'icon-edit',
        //    handler: EditOrder,
        //},
        {
            text: '审核',
            iconCls: 'icon-ok',
            handler: function () {

            },
        },
        {
            text: '|',
        },
        {
            text: '签批',
            iconCls: 'icon-ok',
            handler: function () {

            },
        }
        ],
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
        rownumbers: true,
        singleSelect:true,
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
                        panelHeigth:400,
                        idField:'ID',
                        textField:'Code',
                        //required:true,
                        //valueField: 'SectionbarID',
                        //textField: 'SectionbarCode',
                       // method: 'get',
                        url: '/BasicData/Sectionbar/GetSectionbar',
                        pagination: true,
                        pagePosition: "bottom",
                        pageSize:20,
                        columns: [[
                            { field: 'ID', title: '型号ID', hidden:true},
                            { field: 'Code', title: '型材型号', width: 120 },
                            { field: 'Name', title: '型材名称', width: 120 },
                        ]],
                        onClickRow: function (i, r) {
                            var rows = detailGrid.datagrid('getRows');
                            if (rows!=undefined && rows.length>0 && editIndex!=undefined) {
                                var row = rows[editIndex];
                                row.SectionbarID = r.ID;
                                row.SectionbarCode = r.Code;
                                row.SectionbarName = r.Name;
                                RefreshRow(editIndex);
                            }
                            
                        }
                        
                    }
                }
            }, 
            { field: 'SectionbarName', title: '型材名称', width: 80 },
            {
                field: 'Quantity', title: '数量', width: 80,
                editor:'numberbox' 
            },
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
      //  onClickRow: onClickRow,
        onClickCell:onClickCell,
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

    /*确定保存订单*/
    $('#bSave').linkbutton({
        iconCls: 'icon-ok',
        onClick: function () {
            accept(); 
            var str = "";
            var o = [];
            $.each( $("input"), function (a, b) {
                var N = $(b).attr("id"); 
                /*有这个控件*/
                if (N != undefined) {
                    if ($(b).hasClass('editvalue')) {
                        str = str + '"' + N + '":"' + $('#' + N).val() + '",';
                    }  
                }
            }); 
            str = str.substring(0,str.length - 1);
            var rows = detailGrid.datagrid('getRows'); 
            var obj = eval('({' + str + '})');
            obj.Rows = rows;
            $.ajax({
                type: 'post',
                dataType:'json',
                url: '/Order/OrderIndex/Save/'+obj.ID,
                data: JSON.stringify(obj),
                success: function (data) {
                    if (data) {
                        $.procAjaxMsg(data, function () {
                            if (data.Msg) {
                                $.alertMsg(data.Msg)
                            } 
                        });
                    }
                    detailWindow.window('close');
                }
            })
           
        },
    });
    /*取消关闭窗口*/
    $('#bCancel').linkbutton({
        iconCls: 'icon-ok',
        onClick: function () {
            reject();
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
        ShowDetail({ title: '新增订单', State:1 }); 
    };
    /*修改订单*/
    function EditOrder() {
        var row = datagrid.datagrid('getSelected');
        if (row) {
            ShowDetail({ title: '修改订单--[' + row.BillCode + ']', ID: row.ID, State: 2 });
        }  
    };

    /*打开订单明细的参数*/
    formParam = {
        title: "",
        ID: "",
        State:0,
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
    var editRow = undefined;
    function endEditing() {
        if (editIndex == undefined) {
            return true;
        }
        var row = detailGrid.datagrid('getRows')[0];
        if (detailGrid.datagrid('validateRow', editIndex)) {
            //var ed = detailGrid.datagrid('getEditor', { index: editIndex, field: 'Quantity' });
            detailGrid.datagrid('endEdit', editIndex);
            editIndex = undefined;
            return true;
        } else {
            return false;
        }
    };
    function onClickCell(index,field)
    {
        if (endEditing()) {
            detailGrid.datagrid('selectRow', index).datagrid('editCell', { index: index, field: field });
            editIndex = index;
        }
    }
    function onClickRow(index,row) {
        if (editIndex != index)
        {
            if (endEditing()) {
                detailGrid.datagrid('selectRow', index).datagrid('beginEdit', index);
                editIndex = index;
                editRow = row;
            }
            else {
                detailGrid.datagrid('selectRow', editIndex);
            }
        }
    }
    /*增行*/
    function append() {
        //if (editIndex!=undefined) {
        //    detailGrid.datagrid('validateRow', editIndex);
        //}
        if (endEditing()) {
            editIndex = detailGrid.datagrid('getRows').length;
            detailGrid.datagrid('appendRow', { DNo: detailGrid.datagrid('getRows').length + 1 });

           // detailGrid.datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
        }
       
    };
    /*删行*/
    function delRow() {
        if (editIndex==undefined) {
            return
        }
        detailGrid.datagrid('cancelEdit', editIndex).datagrid('deleteRow', editIndex);
        editIndex = undefined;
        editRow = undefined;
    };
    /*保存修改*/
    function accept() {
        if (endEditing()) {
            detailGrid.datagrid('acceptChanges');
            editIndex = undefined;
            editRow = undefined;
        }
    };
    /*放弃修改*/
    function reject() {
        if (endEditing()) {
            detailGrid.datagrid('rejectChanges');
            editIndex = undefined;
            editRow = undefined;
        }
    };

    /*编辑状态下刷新数据*/
    function RefreshRow(index) {
        if (index != undefined) {
            detailGrid.datagrid('endEdit', index).datagrid('refreshRow', index);
            //detailGrid.datagrid('endEdit', index).datagrid('refreshRow', index).datagrid('beginEdit', index);
        } 
    }

   
    
});


/*显示订单明细*/
function ShowDetail(param) {
    var mainUrl = '/Order/OrderIndex/GetOrder/';
    var detailUrl = '/Order/OrderIndex/GetOrderDetail/';

    detailWindow = $('#detailWindow').window({
        title: param.title,
        modal: true,
        resizable: false,
        minimizable: false,
        maximizable: false,
        draggable: false,
        onClose: function () {
            datagrid.datagrid('reload');
        }
    });
    $.ajax({
        type: 'post',
        url: mainUrl + param.ID,
        success: function (data) {
            if (data) {
                $.each($("input"), function (a, b) {
                    var N = $(b).attr("id");
                    /*有这个控件*/
                    if (N != undefined) {
                        /*json对象有这个属性*/
                        var V = data[N];
                        if (V != undefined) {
                            /*设置只读*/ 
                          //  $('#' + N).textbox('readonly', param.State == 0); 
                            if (N.indexOf("ID") > 0) {
                                if ($(b).attr("class").indexOf("combogrid") > 0) {
                                    $('#' + N).combogrid('setValue', { ID: V.ID, Name: V.Name });
                                    $('#' + N).combogrid('disable', param.State == 0);
                                    return;
                                }
                            }
                            var v = V + "";
                            if (v.indexOf('Date') > 0) {
                                $('#' + N).textbox('setValue', formatDatebox(V));

                                $('#' + N).textbox('disable', param.State == 0);
                                // $('#' + N).textbox('setText', formatDatebox(V));
                            }
                            else {
                                if ($(b).attr("class").indexOf("textbox") > 0) {
                                    $('#' + N).textbox('setText', V);
                                    $('#' + N).textbox('setValue', V); 
                                    $('#' + N).textbox('disable', param.State == 0);
                                }
                                else {
                                    $('#' + N).text(V);
                                    $('#' + N).val(V);
                                } 
                            }

                           
                        }
                        
                    }
                });
                $('#detaildatagrid').datagrid({
                    url: detailUrl + data.ID,
                })
            }
        }
    });
    detailWindow.window('open').window('maximize');
}

/*查看订单明细*/
function viewrow(row) {
    var id = $(row).attr('rowID');
    if (id.length>0) {
        ShowDetail({ title: '订单--[' + $(row).attr('BillCode') + ']', ID: id, State: 0 });
    }
};

/*编辑订单明细*/
function editrow(row) {
    var id = $(row).attr('rowID');
    if (id.length>0) {
        ShowDetail({ title: '修改订单--[' + $(row).attr('BillCode') + ']', ID: id, State: 2 });
    } 
};

/*删除订单*/
function deleterow(row) {
    var id = $(row).attr('rowID');
    if (id.length > 0) {
        $.messager.confirm("请确认", "确认要删除订单吗？", function (r) {
            if (r) { 
                $.ajax({
                    type: 'post',
                    url: '/Order/OrderIndex/DeleteOrder/'+id,
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
}