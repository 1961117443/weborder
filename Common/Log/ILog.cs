using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Log
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public interface ILog
    {
        #region Debug
        void Debug(object message);
        void Debug(object message, Exception exception);
        void DebugFormat(IFormatProvider provider, string format, params object[] args);
        void DebugFormat(string format, object arg0, object arg1, object arg2);
        void DebugFormat(string format, object arg0, object arg1);
        void DebugFormat(string format, object arg0);
        void DebugFormat(string format, params object[] args);
        #endregion

        #region Error
        void Error(object message);
        void Error(object message, Exception exception);
        void ErrorFormat(IFormatProvider provider, string format, params object[] args);
        void ErrorFormat(string format, object arg0, object arg1, object arg2);
        void ErrorFormat(string format, object arg0, object arg1);
        void ErrorFormat(string format, object arg0);
        void ErrorFormat(string format, params object[] args);
        #endregion

        #region Fatal
        void Fatal(object message);
        void Fatal(object message, Exception exception);
        void FatalFormat(IFormatProvider provider, string format, params object[] args);
        void FatalFormat(string format, object arg0, object arg1, object arg2);
        void FatalFormat(string format, object arg0, object arg1);
        void FatalFormat(string format, object arg0);
        void FatalFormat(string format, params object[] args);
        #endregion

        #region Info
        void Info(object message);
        void Info(object message, Exception exception);
        void InfoFormat(IFormatProvider provider, string format, params object[] args);
        void InfoFormat(string format, object arg0, object arg1, object arg2);
        void InfoFormat(string format, object arg0, object arg1);
        void InfoFormat(string format, object arg0);
        void InfoFormat(string format, params object[] args);
        #endregion

        #region Warn
        void Warn(object message);
        void Warn(object message, Exception exception);
        void WarnFormat(IFormatProvider provider, string format, params object[] args);
        void WarnFormat(string format, object arg0, object arg1, object arg2);
        void WarnFormat(string format, object arg0, object arg1);
        void WarnFormat(string format, object arg0);
        void WarnFormat(string format, params object[] args);
        #endregion
    }
}
