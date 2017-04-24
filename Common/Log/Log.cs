using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Log
{
    public class Log : ILog
    {
        private Type type;
        private log4net.ILog log;

        public Log()
        {
            type = GetType();
        }
        public Log(Type t)
        {
            type = t;
        }

        public log4net.ILog LogHelper
        {
            get
            {
                if (log==null)
                {
                    lock(this)
                    {
                        if (log==null)
                        {
                            log = log4net.LogManager.GetLogger(type);
                        }
                    }
                }
                return log;
            }
        }
        #region Debug
        public void Debug(object message)
        {
            LogHelper.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            LogHelper.Debug(message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            LogHelper.DebugFormat(format, args);
        }

        public void DebugFormat(string format, object arg0)
        {
            LogHelper.DebugFormat(format, arg0);
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            LogHelper.DebugFormat(format, arg0, arg1);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            LogHelper.DebugFormat(provider, format, args);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            LogHelper.DebugFormat(format, arg0, arg1, arg2);
        }
        #endregion

        #region Error
        public void Error(object message)
        {
            LogHelper.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            LogHelper.Error(message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            LogHelper.ErrorFormat(format, args);
        }

        public void ErrorFormat(string format, object arg0)
        {
            LogHelper.ErrorFormat(format, arg0);
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            LogHelper.ErrorFormat(format, arg0,arg1);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            LogHelper.ErrorFormat(provider,format, args);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            LogHelper.ErrorFormat(format, arg0, arg1, arg2);
        }
        #endregion

        #region Fatal
        public void Fatal(object message)
        {
            LogHelper.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            LogHelper.Fatal(message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            LogHelper.FatalFormat(format, args);
        }

        public void FatalFormat(string format, object arg0)
        {
            LogHelper.FatalFormat(format, arg0);
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            LogHelper.FatalFormat(format, arg0, arg1);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            LogHelper.FatalFormat(provider, format, args);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            LogHelper.FatalFormat(format, arg0, arg1, arg2);
        }
        #endregion

        #region Info
        public void Info(object message)
        {
            LogHelper.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            LogHelper.Info(message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            LogHelper.InfoFormat(format, args);
        }

        public void InfoFormat(string format, object arg0)
        {
            LogHelper.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            LogHelper.InfoFormat(format, arg0, arg1);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            LogHelper.InfoFormat(provider, format, args);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            LogHelper.InfoFormat(format, arg0, arg1, arg2);
        }
        #endregion

        #region Warn
        public void Warn(object message)
        {
            LogHelper.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            LogHelper.Warn(message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            LogHelper.WarnFormat(format, args);
        }

        public void WarnFormat(string format, object arg0)
        {
            LogHelper.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            LogHelper.WarnFormat(format, arg0, arg1);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            LogHelper.WarnFormat(provider, format, args);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            LogHelper.WarnFormat(format, arg0, arg1, arg2);
        }
        #endregion
    }
}
