using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBLL;
using DI;

namespace MvcWebOrder.Controllers
{
    public class OperContext
    {
        private IBLLSession _BLLSession;
        public IBLLSession BLLSession
        {
            get
            {
                if (_BLLSession==null)
                {
                    IBLLSessionFactory bllSessionFactory = SpringHelper.GetObject<IBLLSessionFactory>("BLLSessionFactory");
                    _BLLSession = bllSessionFactory.GetBLLSession();
                }
                return _BLLSession;
            }
        }
    }
}