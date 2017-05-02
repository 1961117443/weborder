using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Common;
using Models;

namespace MvcWebOrder.Controllers
{
    public class BaseController:Controller
    {
        protected virtual ActionResult PackagingAjaxmsg(AjaxStatu statu, string msg, string url="", object data=null)
        {
            return new JsonResult() { Data = new AjaxMsgModel(statu, msg, url, data) };
        }

        protected virtual ActionResult PackagingAjaxmsg(AjaxMsgModel amodel)
        {
            return new JsonResult() { Data = amodel };
        }
    }
}
