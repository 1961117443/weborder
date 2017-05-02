using Common;
using Models;
using MvcWebOrder.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebOrder.Controllers
{
    public class AdminLoginController : BaseController
    {
        // GET: AdminLogin
        /// <summary>
        /// 数据操作上下文
        /// </summary>
        OperContext oc = OperContext.CurrentOperContext;
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
        public ActionResult LoginIn()
        {
            if (Request["lname"] ==null || Request["lpwd"] == null || Request["lcode"] == null)
            {
                return PackagingAjaxmsg(AjaxStatu.err, "登录名|密码|验证码，没有传入后台！");
            }
            string userName = Request["lname"];
            string passWord = Request["lpwd"];
            string code = Request["lcode"];
            return PackagingAjaxmsg(Model_UserInfo.LoginIn(userName, passWord, code));
        }
        #endregion

        public ActionResult GetValidateCode()
        {
            return File(Model_UserInfo.GenerateValidateCode(), @"image/jpeg");
        }
    }
}