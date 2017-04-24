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

    }
}
