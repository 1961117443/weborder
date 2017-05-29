using Models;
using MvcWebOrder.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.ComponentModel;

namespace MvcWebOrder.Areas.BasicData.Controllers
{
    [Description("客户档案")]
    public class CustomerController : BaseController
    {
        // GET: BasicData/Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCustomer()
        {
            int total = 0;
            var list = oc.BLLSession.ICustomerBLL.Entities.Where(c => 1 == 1, out total, null).Select(c => new { c.ID, c.Code, c.Name }).ToList();
            DataGrid dg = new DataGrid()
            {
                total = total,
                rows = list,
                footer = null
            };
            return Json(dg, JsonRequestBehavior.AllowGet);
        }
    }
}