using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DI
{
    public class SpringHelper
    {

        #region Spring.NET 容器上下文
        private static IApplicationContext SpringContext
        {
            get
            {
                return ContextRegistry.GetContext();
            }
        } 
        #endregion
        #region 使用Spring操作配置文件并转化为对象
        public static T GetObject<T>(string objName) where T : class
        {
            T obj = (T)SpringContext.GetObject(objName);
            return obj;
        } 
        #endregion
    }
}
