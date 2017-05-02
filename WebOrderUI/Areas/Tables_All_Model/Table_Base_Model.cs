using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebOrder.Areas
{
    public class Table_Base_Model
    {
        #region 数据操作上下文
        public static OperContext OperContext
        {
            get
            {
                return OperContext.CurrentOperContext;
            }
        } 
        #endregion
    }
}