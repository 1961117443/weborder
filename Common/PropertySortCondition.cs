using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
namespace Common
{
    /// <summary>
    /// 属性排序条件
    /// </summary>
    public class PropertySortCondition
    {
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 排序方式
        /// </summary> 
        public SortDirection SortDirection { get; set; }

        #region 构造函数
        public PropertySortCondition(string propertyName, SortDirection sortDirection)
        {
            PropertyName = propertyName;
            SortDirection = sortDirection;
        }
        public PropertySortCondition(string propertyName) : this(propertyName, SortDirection.Ascending)
        {

        } 
        #endregion
    }
}
