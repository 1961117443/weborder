using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebOrder.Areas.Admin.Controllers
{
    public class AdminIndexController : Controller
    {
        // GET: Admin/AdminIndex
        public ActionResult Index()
        {
            return View();
        }
    }
}