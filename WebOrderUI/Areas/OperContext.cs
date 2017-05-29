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
        #region 封装HTTP对象
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
        #endregion
        #region 当前验证码
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
        #endregion
        #region 当前用户
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
         
        #endregion 
        #region 保存当前登录用户的用户名

        
        HttpCookie cookie;
        /// <summary>
        /// 保存当前登录用户的用户名
        /// </summary>
        public string CurrentLoginName
        {
            set
            {
                string name = Common.SecurityHelper.MD5Encrypt32(value);
                cookie = new HttpCookie(AppMsg.Admin_Cookie_UserLoginName, name);
                cookie.Expires = DateTime.Now.AddDays(7);
                cookie.Path = AppMsg.Admin_Cookie_Path;
                Response.Cookies.Add(cookie);
            }
            get
            {
                if (Response.Cookies[AppMsg.Admin_Cookie_UserLoginName] == null)
                {
                    return "";
                }
                string name = Response.Cookies[AppMsg.Admin_Cookie_UserLoginName].Value;

                return Common.SecurityHelper.MD5Encrypt(name);
            }
        } 

        public string CurrentLoginUserID
        {
            set
            {
                string id = SecurityHelper.MD5Encrypt32(value);
                cookie = new HttpCookie(AppMsg.Admin_Cookie_UserLoginID, id);
                cookie.Expires = DateTime.Now.AddDays(7);
                cookie.Path = AppMsg.Admin_Cookie_Path;
                Response.Cookies.Add(cookie);
            }
            get
            {
                if (Response.Cookies[AppMsg.Admin_Cookie_UserLoginID]==null)
                {
                    return "";
                }
                string id = Response.Cookies[AppMsg.Admin_Cookie_UserLoginID].Value;
                return SecurityHelper.MD5Encrypt(id);
            }
        }
        #endregion


    }
}