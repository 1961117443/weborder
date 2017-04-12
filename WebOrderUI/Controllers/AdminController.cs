using System.Web.Mvc;
using Models;
using Common;
using System.Collections.Generic;
using System;

namespace MvcWebOrder.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin 
        #region 首页
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetModules()
        {
            OperContext oc = OperContext.CurrentOperContext;
            List<SysModule> modules = oc.BLLSession.ISysModuleBLL.GetList(null,m=>m.OrderID);
            string json = string.Empty;
            if (modules.Count>0)
            {
                json = DataHelper.ObjectToJson(SysModule.GetTreeNode(modules));
            }
            return Content(json);
        } 
        #endregion

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

            OperContext oc = OperContext.CurrentOperContext;

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
                    return oc.PackagingAjaxMsg(AjaxStatu.ok, "登录成功", null, "/Admin/Index");
                }
                else
                {
                    return oc.PackagingAjaxMsg(AjaxStatu.err, "密码错误");
                }
            }
        }
        #endregion

        #region 用户信息
        public ActionResult ShowUser()
        {
            return View();
        }
        public ActionResult ShowUsers()
        {
            int page = 0;
            int rows = 0;
            int totalCount=0;
            if (Request["page"] != null)
            {
                int.TryParse(Request["page"].ToString(), out page);
            }
            if (Request["rows"] != null)
            {
                int.TryParse(Request["rows"].ToString(), out rows);
            } 
            OperContext oc = OperContext.CurrentOperContext;
            var users = oc.BLLSession.IUserInfoBLL.GetPageList(page,rows,ref totalCount,null,u=>u.ID,true); 
            DataGrid dg = new DataGrid()
            {
                total = totalCount,
                rows = users,
                footer = null
            }; 
            return Json(dg, JsonRequestBehavior.AllowGet);
        }

        
        #endregion


    }

    
}