using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Common.Log
{
    public class LogHelper
    {
        private static readonly string fileName = "Common.Log.log4net.config";
        #region 初始化log4net
        /// <summary>
        /// 设置日至配置信息
        /// </summary>
        public static void InitLog4Net()
        { 
            log4net.Config.XmlConfigurator.Configure(GetConfig());
        }

        /// <summary>
        /// 设置日至配置信息
        /// </summary>
        /// <param name="configFile"></param>
        public static void InitLog4Net(FileInfo configFile)
        {
            if (configFile != null && configFile.Exists)
            {
                log4net.Config.XmlConfigurator.ConfigureAndWatch(configFile);
            }
            else
            {
                InitLog4Net();
            }
        }

        public static Stream GetConfig()
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);
        }
        #endregion
        #region 利用Action委托封装log4net对方法的处理方法
        /// <summary>
        /// 利用Action委托封装log4net对方法的处理方法
        /// </summary>
        /// <param name="log">日志对象</param>
        /// <param name="function">方法名</param>
        /// <param name="errorHandle">异常处理方法</param>
        /// <param name="tryHandle">调试/运行代码</param>
        /// <param name="catchHandle">异常处理方式</param>
        /// <param name="finallyHandle">最终处理方式</param>
        public static void Logger(ILog log, string function, ErrorHandle errorHandle, Action tryHandle, Action<Exception> catchHandle = null, Action finallyHandle = null)
        {
            try
            {
                log.Debug(function);
                tryHandle();
            }
            catch (Exception ex)
            {
                log.Error(function + "失败", ex);
                catchHandle?.Invoke(ex);
                if (errorHandle == ErrorHandle.Throw)
                {
                    throw ex;
                }
            }
            finally
            {
                finallyHandle?.Invoke();
            }
        } 
        #endregion

    }
}
