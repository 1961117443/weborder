using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBLL;
using DI;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;
using Models;
using Common;
using System.Web.SessionState;

namespace MvcWebOrder.Areas
{
    public class OperContext
    {

       
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

        #region 把ajax返回值封装成json格式返回
        public ActionResult PackagingAjaxMsg(AjaxStatu statu, string msg, object data = null, string backurl = "")
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


        HttpContext ContextHttp
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public HttpResponse Response
        {
            get
            {
                return ContextHttp.Response;
            }
        }

        public HttpRequest Request
        {
            get
            {
               return ContextHttp.Request;
            }
        }

        public HttpSessionState Session
        {
            get
            {
                return ContextHttp.Session;
            }
        }

        public string CurrentUserValidateCode
        {
            get
            {
                return (string)Session[AppMsg.Session_ValidateCode];
            }
            set
            {
                Session[AppMsg.Session_ValidateCode] = value;
            }
        }

        public UserInfo CurrentUser
        {
            get
            {
                return Session[AppMsg.Session_CurrentUser] as UserInfo;
            }
            set
            {
                Session[AppMsg.Session_CurrentUser] = value;
            }
        }

    }
}