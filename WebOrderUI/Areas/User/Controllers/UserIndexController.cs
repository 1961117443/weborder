using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebOrder.Areas.User.Controllers
{
    public class UserIndexController : Controller
    {
        // GET: User/UserIndex
        //public ActionResult Index()
        //{
        //    return View();
        //}
        /// <summary>
        /// 数据操作上下文
        /// </summary>
        OperContext oc = OperContext.CurrentOperContext;

        #region 获取模块列表 
        public ActionResult GetModules()
        {
            List<SysModule> modules = OperContext.CurrentOperContext.CurrentUser.PermissionModule;
            string json = string.Empty;
            if (modules!=null && modules.Count > 0)
            {
                json = DataHelper.ObjectToJson(SysModule.GetTreeNode(modules));
            }
            return Content(json);
        }
        #endregion
        #region Tab首页
        public ActionResult TabIndex()
        {
            return View();
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
            int totalCount = 0;
            string userName = string.Empty, ldate = string.Empty, edate = string.Empty;
            if (Request["page"] != null)
            {
                int.TryParse(Request["page"].ToString(), out page);
            }
            if (Request["rows"] != null)
            {
                int.TryParse(Request["rows"].ToString(), out rows);
            }

            if (Request["userName"] != null)
            {
                userName = Request["userName"];
            }
            if (Request["ldate"] != null)
            {
                ldate = Request["ldate"];
            }
            if (Request["edate"] != null)
            {
                edate = Request["edate"];
            }


            var users = oc.BLLSession.IUserInfoBLL.GetPageList(page, rows, ref totalCount, u => userName == string.Empty || u.UserName == userName, u => u.ID, true);
            DataGrid dg = new DataGrid()
            {
                total = totalCount,
                rows = users,
                footer = null
            };
            return Json(dg, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region 修改密码
        public ActionResult ModifyUserForm()
        {
            return View();
        } 
        #endregion
    }
}