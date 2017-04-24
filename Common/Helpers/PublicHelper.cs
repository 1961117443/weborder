using Common.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class PublicHelper
    {
        #region 验参数合法性，数值类型不能小于0，引用类型不能为null，否则抛出相应异常
        /// <summary>
        /// 检验参数合法性，数值类型不能小于0，引用类型不能为null，否则抛出相应异常
        /// </summary>
        /// <param name="arg">待检参数</param>
        /// <param name="argName">待检参数名称</param>
        /// <param name="canZeor">数值类型是否可以等于0</param>
        public static bool CheckArgument(object arg, string argName, bool canZero = false)
        {

            try
            {
                if (arg == null)
                {
                    ArgumentNullException e = new ArgumentNullException(argName);
                    throw new Exception(string.Format("参数{0}为空引发异常。", argName), e);
                    Type type = arg.GetType();
                    if (type.IsValueType && type.IsNumeric())
                    {
                        bool flag = !canZero ? arg.CastTo(0.0) <= 0.0 : arg.CastTo(0.0) < 0.0;
                        if (flag)
                        {
                            ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException(argName);
                            throw new Exception(string.Format("参数{0}不在有效范围内，引发异常。具体信息请查看系统日志。", argName), ex);
                        }
                    }
                    if (type == typeof(Guid) && (Guid)arg == Guid.Empty)
                    {
                        ArgumentNullException ex = new ArgumentNullException(argName);
                        throw new Exception(string.Format("参数{0}为空引发GUID异常。", argName), ex);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("检验数据合法性", ex);
            }
            return false;
        } 
        #endregion

        #region 日志
        private static ILog defaultLog;
        public static ILog Log
        {
            get
            {
                if (defaultLog == null)
                {
                    defaultLog = LogFactory.GetLog(typeof(PublicHelper));
                }
                return defaultLog;
            }
        } 
        #endregion
    }
}
