using MvcWebOrder.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebOrder.Areas.Admin.Controllers
{
    public class AdminIndexController : BaseController
    {
        // GET: Admin/AdminIndex
        
        public ActionResult Index()
        {
            ViewData["loginUser"] = oc.CurrentUser;
            return View();
        }
    }
}