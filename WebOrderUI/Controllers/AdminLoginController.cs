using Common;
using Common.Attributes;
using Models;
using MvcWebOrder.Areas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebOrder.Controllers
{
    [Description("用户登录")]
    public class AdminLoginController : BaseController
    {
        // GET: AdminLogin
        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Skip]
        public ActionResult LoginIn()
        {
            if (Request["lname"]==null || Request["lpwd"] == null || Request["lcode"] == null )
            {
                return PackagingAjaxmsg(new AjaxMsgModel(AjaxStatu.err, "登录名|密码|验证码，传入为空！"));
            }
            string userName = Request["lname"];
            string passWord = Request["lpwd"];
            string code = Request["lcode"]; 
            return PackagingAjaxmsg(Model_UserInfo.LoginIn(userName, passWord, code));
        }
        #endregion

        [HttpPost]
        public ActionResult LoginOut()
        {
            Session.Abandon();
            return PackagingAjaxmsg(new AjaxMsgModel(AjaxStatu.ok, "退出成功", "/AdminLogin/Login"));
        }

        public ActionResult GetValidateCode()
        {
            return File(Model_UserInfo.GenerateValidateCode(), @"image/jpeg");
        }
    }
}