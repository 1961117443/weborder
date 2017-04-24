using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Log;

namespace MvcWebOrder
{
    public class FrameworkConfig
    {
        public static void Register()
        {
            LogHelper.InitLog4Net();
        }
    }
}