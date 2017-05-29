using Common;
using Common.Attributes;
using MvcWebOrder.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebOrder.Areas.Filters
{
    public class LoginValidateAttribute: AuthorizeAttribute
    {
        //
        // 摘要:
        //     在过程请求授权时调用。
        //
        // 参数:
        //   filterContext:
        //     筛选器上下文，它封装有关使用 System.Web.Mvc.AuthorizeAttribute 的信息。
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     filterContext 参数为 null。
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // base.OnAuthorization(filterContext);
            /**
             * 如果请求的区域包含area并且area的名称等于Admin
             * 那么就进行权限验证
             * */
            if (filterContext.RouteData.DataTokens.Keys.Contains("area") )
              //  && filterContext.RouteData.DataTokens["area"].ToString().ToLower().IndexOf("_area")>0)
            {
                /*
                 * Action方法本身以及它所属的控制器都没有定义Skip特性
                 * 那么就进行权限验证
                 */
                if (!filterContext.ActionDescriptor.IsDefined(typeof(SkipAttribute),false)
                    && !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(SkipAttribute),false))
                {
                    /*
                     * 判断有没有登录 
                     */
                    if (!Model_UserInfo.IsLogin())
                    {
                        filterContext.Result = new BaseController().Redirect("/AdminLogin/Login", filterContext.ActionDescriptor,AjaxStatu.nologin);
                        return;
                    }
                    string areaName = filterContext.RouteData.DataTokens["area"].ToString();
                    string actionName = filterContext.ActionDescriptor.ActionName;
                    string controlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                    string httpMethod = filterContext.RequestContext.HttpContext.Request.HttpMethod;
                    RequestMethod method = httpMethod.ToLower().Equals("get") ? RequestMethod.GET : httpMethod.ToLower().Equals("post") ? RequestMethod.POST : RequestMethod.HEAD;
                    if (!Model_SysModule.ExistsPermission(areaName, controlName, actionName, method))
                    {
                        filterContext.Result = new BaseController().Redirect("/AdminLogin/Login", filterContext.ActionDescriptor,AjaxStatu.nopermission);
                        return;
                    }
                }
            }
        }
    }
}