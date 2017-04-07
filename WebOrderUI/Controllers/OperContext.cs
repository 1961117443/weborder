using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBLL;
using DI;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;
using Models;

namespace MvcWebOrder.Controllers
{
    public class OperContext
    {
        #region OldCode
        /*
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
        */
        #endregion

        #region 使用线程优化业务层仓储
        public IBLLSession BLLSession;

        private OperContext()
        {
            BLLSession = SpringHelper.GetObject<IBLLSession>("BLLSession");
        }

        public static OperContext CurrentOperContext
        {
            get
            {
                var opc = CallContext.GetData(typeof(OperContext).Name) as OperContext;
                if (opc == null)
                {
                    opc = new OperContext();
                    CallContext.SetData(typeof(OperContext).Name, opc);
                }
                return opc;
            }
        }
        #endregion

        #region 把ajax返回值封装成jsoon格式返回
        public ActionResult PackagingAjaxMsg(string statu, string msg, object data = null, string backurl = "")
        {
            AjaxMsgModel am = new AjaxMsgModel()
            {
                Statu = statu,
                Msg = msg,
                Data = data,
                BackUrl = backurl
            };
            JsonResult ajaxResult = new JsonResult();
            ajaxResult.Data = am;
            return ajaxResult;
        } 
        #endregion

    }
}