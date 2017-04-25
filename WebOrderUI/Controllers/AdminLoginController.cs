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
    public class AdminLoginController : Controller
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

            string userName = Request["name"];
            string passWord = Request["pwd"];

            var users = oc.BLLSession.IUserInfoBLL.GetList(u => u.UserName.Equals(userName));
            if (users == null || users.Count == 0)
            {
                return oc.PackagingAjaxMsg(AjaxStatu.err, "用户账号不存在");
            }
            else
            {
                var user = users.Find(u => u.PassWord.Equals(passWord));
                if (user != null)
                {
                    user.LoginTime = DateTime.Now;
                    //把登录信息保存到session中
                    Session["loginUser"] = user;
                    oc.BLLSession.IUserInfoBLL.Modify(user, "LoginTime");
                    //保存cookie
                    //返回ajax信息
                    return oc.PackagingAjaxMsg(AjaxStatu.ok, "登录成功", null, "/User/UserIndex");
                }
                else
                {
                    return oc.PackagingAjaxMsg(AjaxStatu.err, "密码错误");
                }
            }
        }
        #endregion
    }
}