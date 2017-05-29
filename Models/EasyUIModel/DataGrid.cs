using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// EasyUI 的 DataGrid 数据表格
    /// </summary>
    public class DataGrid
    {
        /// <summary>
        /// 记录总数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 表格数据
        /// </summary>
        public object rows { get; set; }
        /// <summary>
        /// 页脚数据
        /// </summary>
        public object footer { get; set; }

        public List<Column> title { get; set; }
    }

    public class Column
    {
        public string field { get; set; }
        public string title { get; set; }

        public bool checkbox { get; set;}
    }
}
