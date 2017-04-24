using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Log
{
   public  class BaseLog<T> where T:new()
    {
       protected static ILog log = new Log(typeof(T));

        protected  void Logger(string function,Action tryHandle,Action<Exception> catchHandle=null,Action  finallyHandle = null)
        {
            LogHelper.Logger(log, function, ErrorHandle.Throw, tryHandle, catchHandle, finallyHandle);
        }

        protected void Logger(DBAction action, Action tryHandle, Action<Exception> catchHandle = null, Action finallyHandle = null)
        {
            LogHelper.Logger(log, GetAction(action), ErrorHandle.Throw, tryHandle, catchHandle, finallyHandle);
        }

        public  string GetAction(DBAction action)
        {
            string rstr = "";
            switch (action)
            {
                case DBAction.None:
                    rstr = "{0}";
                    break;
                case DBAction.Add:
                    rstr = "向表{0}添加数据";
                    break;
                case DBAction.Modify:
                    rstr = "修改表{0}中的数据";
                    break;
                case DBAction.Delete:
                    rstr = "删除表{0}中的数据";
                    break;
                case DBAction.Query:
                    rstr = "查询表{0}中的数据";
                    break;
                default:
                    break;
            }
            return string.Format(rstr, typeof(T));
        }
    }
}
