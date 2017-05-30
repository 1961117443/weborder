using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Models;
using MvcWebOrder.Areas;
using Common.Attributes;
using System.Text;

namespace MvcWebOrder.Controllers
{
    public class BaseController: Controller
    {

        #region 数据操作上下文
        /// <summary>
        /// 数据操作上下文
        /// </summary>
        protected OperContext oc = OperContext.CurrentOperContext; 
        #endregion

        #region 包装成 AjaxMsgModel 返回前端
        protected virtual JsonResult PackagingAjaxmsg(AjaxMsgModel amm)
        {
            JsonResult jr = new JsonResult();
            jr.Data = amm;
            jr.ContentType = "application/json";
            jr.ContentEncoding = Encoding.UTF8;
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jr;
        }

        protected virtual JsonResult PackagingAjaxmsg(AjaxStatu statu, string msg, string url = "", object data = null)
        {
            return PackagingAjaxmsg(new AjaxMsgModel(statu, msg, url, data));
        }
        #endregion

        #region 页码和页大小
        protected int Page
        {
            get
            {
                int page = 0;
                if (Request["page"] != null)
                {
                    int.TryParse(Request["page"].ToString(), out page);
                }
                return page;
            }
        }

        protected int Rows
        {
            get
            {
                int rows = 0;
                if (Request["rows"] != null)
                {
                    int.TryParse(Request["rows"].ToString(), out rows);
                }
                return rows;
            }
        }
        #endregion

        #region 系统重定向
        public ActionResult Redirect(string url, ActionDescriptor action,AjaxStatu statu)
        {
            //判断是否Ajax请求
            if (action.IsDefined(typeof(AjaxRequestAttribute), false) ||
                action.ControllerDescriptor.IsDefined(typeof(AjaxRequestAttribute), false))
            {
                //判断是否有权限
                if (statu == AjaxStatu.nopermission)
                {
                    return PackagingAjaxmsg(new AjaxMsgModel(statu, string.Format("你没有操作【{0}】的权限！",action.Description()), null,""));
                }
                return PackagingAjaxmsg(new AjaxMsgModel(statu, "请先登录！", null, url));
            }
            return new RedirectResult(url);
        } 
        #endregion
    }
}