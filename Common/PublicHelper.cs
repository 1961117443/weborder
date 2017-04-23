using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class PublicHelper
    {
        /// <summary>
        /// 检验参数合法性，数值类型不能小于0，引用类型不能为null，否则抛出相应异常
        /// </summary>
        /// <param name="arg">待检参数</param>
        /// <param name="argName">待检参数名称</param>
        /// <param name="canZeor">数值类型是否可以等于0</param>
        public static void CheckArgument(object arg,string argName,bool canZero=false)
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
                        bool flag = !canZero ? arg.Cast(0.0) <= 0.0 : arg.Cast(0.0) < 0.0;
                        if (flag)
                        {
                            ArgumentOutOfRangeException e = new ArgumentOutOfRangeException(argName);
                            throw new Exception(string.Format("参数{0}不在有效范围内，引发异常。具体信息请查看系统日志。", argName));
                        }
                    }
                    if (type==typeof(Guid) && (Guid)arg==Guid.Empty)
                    {
                        ArgumentNullException e = new ArgumentNullException(argName);
                        throw new Exception(string.Format("参数{0}为空引发异常。", argName), e);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
