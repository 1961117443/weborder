using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Common
{
    public class LogHelper
    {
        #region 初始化log4net
        public static void InitLog4Net()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var xml = assembly.GetManifestResourceStream("Common.Log.log4net.config");
            log4net.Config.XmlConfigurator.Configure(xml);
        } 
        #endregion

    }
}
