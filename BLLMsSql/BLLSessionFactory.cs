using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBLL;
using System.Runtime.Remoting.Messaging;

namespace BLLMsSql
{
    public class BLLSessionFactory : IBLLSessionFactory
    {
        public IBLLSession GetBLLSession()
        {
            IBLLSession bllSession = CallContext.GetData(typeof(BLLSessionFactory).Name) as IBLLSession;
            if (bllSession==null)
            {
                bllSession = new BLLSession();
                CallContext.SetData(typeof(BLLSessionFactory).Name, bllSession);
            }
            return bllSession;
        }
    }
}
