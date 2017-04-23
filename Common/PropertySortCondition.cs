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
        public string PropertyName { get; set; }
        public SortDirection SortDirection { get; set; }

        public PropertySortCondition(string propertyName,SortDirection sortDirection)
        {
            PropertyName = propertyName;
            SortDirection = sortDirection;
        }
        public PropertySortCondition(string propertyName):this(propertyName,SortDirection.Ascending)
        {

        }
    }
}
