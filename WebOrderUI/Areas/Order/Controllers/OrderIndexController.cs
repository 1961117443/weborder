using Models;
using MvcWebOrder.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace MvcWebOrder.Areas.Order.Controllers
{
    public class OrderIndexController : BaseController
    {
        // GET: Order/OrderIndex
        public ActionResult Index()
        {
            return View();
        }

        #region 显示订单列表
        public ActionResult ShowOrders()
        {

            int totalCount = 0;
            string userName = string.Empty, ldate = string.Empty, edate = string.Empty;

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
            var orders = oc.BLLSession.ISalesOrderBLL.Entities.Where(o => 1 == 1, Page, Rows, out totalCount, new PropertySortCondition("OrderDate")).Select(o => new { ID = o.ID, BillCode = o.BillCode, OrderDate = o.OrderDate, CustName = o.Customer.Name, Remark = o.Remark }).ToList();
            DataGrid dg = new DataGrid()
            {
                total = totalCount,
                rows = orders,
                footer = null
            };
            return Json(dg, JsonRequestBehavior.AllowGet);
        }

        #endregion 

       
        public ActionResult GetOrder()
        {
            string ID = Request["ID"] ?? string.Empty;
            var orders = oc.BLLSession.ISalesOrderBLL.Entities.Where(s => s.ID.ToString() == ID).Select(o => new { ID=o.ID, BillCode = o.BillCode, OrderDate = o.OrderDate, CustomerID = o.CustomerID, CustomerName = o.Customer.Name }).FirstOrDefault();
            if (orders==null)
            {
                return Json(new { BillCode = "tt17051101", OrderDate = DateTime.Now }, JsonRequestBehavior.AllowGet);
            }
            
            return Json(orders, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOrderDetail()
        {
            string ID = Request["ID"] ?? "-1";
            int totalCount = 0; 
            
            var orders = oc.BLLSession.ISalesOrderDetailBLL.Entities.Where(o => 1 == 1, Page, Rows, out totalCount, new PropertySortCondition("ID")).Select(d => new { ID = d.ID, SectionbarID = d.SectionbarID, SectionbarCode = d.Sectionbar.Code, SectionbarName = d.Sectionbar.Name, Quantity = d.Quantity }).ToList();
            DataGrid dg = new DataGrid()
            {
                total = totalCount,
                rows = orders,
                footer = null
            };
            return Json(dg, JsonRequestBehavior.AllowGet);
        }





        #region 删除订单
        public ActionResult DeleteOrder()
        {
            string ids = Request["ids"] ?? string.Empty;
            string[] idArray = ids.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var r = oc.BLLSession.ISalesOrderBLL.Del(o => idArray.Contains(o.ID.ToString()));
            return PackagingAjaxmsg(new AjaxMsgModel(AjaxStatu.ok, "成功删除" + r + "份订单!"));
        } 
        #endregion
    }
}