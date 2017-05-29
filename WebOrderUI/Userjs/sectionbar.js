 
$(function () { 
    var datagrid;
    datagrid = $('#datagrid').datagrid({
        fitColumns: true,
        url: "/BasicData/Sectionbar/ShowDetail",
        title: "型号列表",
        iconCls: "icon-save",
        fit: true,
        pagination: true,
        pagePosition: "bottom",
        checkOnSelect: false,
        selectOnCheck: false,
        pageList: [10, 20, 30, 40, 50],
        pageSize: 20,
        showFooter: true,
        columns: [[
            { field: 'ID', checkbox: true },
            { field: 'Code', title: '型材型号', width: 100 },
            { field: 'Name', title: '型材名称', width: 100 }
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

    $('#btnQuery').linkbutton({
        iconCls: 'icon-search',
        onClick: _search,
    });

    $('#btnCancel').linkbutton({
        iconCls: 'icon-undo',
        onClick: clearSearch,
    });

    function _search() {
        datagrid.datagrid('load', serializeObject($('#searchForm')));
    };

    function clearSearch() {
        // console.info("1");
        $('#datagrid').datagrid('load', {});
        $('#searchForm input').val("");
    }; 
});
 