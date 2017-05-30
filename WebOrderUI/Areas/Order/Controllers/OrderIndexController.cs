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

        public ActionResult GetOrder(int id)
        {
            SalesOrder order = null;
            if (id>0)
            {
               order = oc.BLLSession.ISalesOrderBLL.Entities.FirstOrDefault(s => s.ID == id);
            }
            else
            {
                order = Model_SalesOrder.CreateOrder();
            }
            var obj = new { ID = order.ID, BillCode = order.BillCode, OrderDate = order.OrderDate, CustomerID = order.Customer == null?"": order.Customer.ID.ToString(), CustomerName = order.Customer==null?"": order.Customer.Name };
           
            return Json(obj, JsonRequestBehavior.AllowGet);
        }  
        public ActionResult GetOrderDetail(int id)
        {
            int totalCount = 0;  
            var orders = oc.BLLSession.ISalesOrderDetailBLL.Entities.Where(o => o.FID==id).Select(d => new { ID = d.ID, SectionbarID = d.SectionbarID, SectionbarCode = d.Sectionbar.Code, SectionbarName = d.Sectionbar.Name, Quantity = d.Quantity }).ToList();
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