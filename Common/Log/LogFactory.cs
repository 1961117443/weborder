using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.Log
{
    /// <summary>
    /// 日志类，默认使用log4net
    /// </summary>
    public static class LogFactory
    {
        private static ILog _defaultLog = null;

        public static ILog DefaultLog
        {
            get
            {
                if (_defaultLog==null)
                {
                    _defaultLog = new Log();
                }
                return _defaultLog;
            }
        }

        /// <summary>
        /// 根据指定名取相应的日志，如sql、text、event(widows日志)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static ILog GetLog(Type t)
        {
            return new Log(t);
        }

        /// <summary>
        /// 设置日至配置信息
        /// </summary>
        /// <param name="configFile"></param>
        public static void SetConfig(FileInfo configFile = null)
        {
            if (configFile!=null && configFile.Exists)
            {
                log4net.Config.XmlConfigurator.ConfigureAndWatch(configFile);
            }
            else
            {
                log4net.Config.XmlConfigurator.Configure(LogHelper.GetConfig());
            }
        }
    }
}
