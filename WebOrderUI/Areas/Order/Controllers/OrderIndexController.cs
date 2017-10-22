using Models;
using MvcWebOrder.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.IO;

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
            var orders = oc.BLLSession.ISalesOrderBLL.Entities.Where(o => 1 == 1, Page, Rows, out totalCount, new PropertySortCondition("OrderDate")).Select(o =>
            new
            {
                ID = o.ID,
                BillCode = o.BillCode,
                OrderDate = o.OrderDate,
                CustName = oc.BLLSession.ICustomerBLL.Entities.FirstOrDefault(c=>c.ID==o.CustomerID).Name,
                Remark = o.Remark
            }).ToList();
            DataGrid dg = new DataGrid()
            {
                total = totalCount,
                rows = orders,
                footer = null
            };
            return Json(dg, JsonRequestBehavior.AllowGet);
        }

        #endregion 

        public ActionResult GetOrder(string id)
        {
            SalesOrder order = null;
            Guid ID = Guid.Empty;
            

            if (!string.IsNullOrEmpty(id))
            {
                if (Guid.TryParse(id,out ID))
                {
                    order = oc.BLLSession.ISalesOrderBLL.Entities.FirstOrDefault(s => s.ID.Equals(ID));
                }
                else
                {
                    return PackagingAjaxmsg(new AjaxMsgModel(AjaxStatu.err, "传入的参数有误！"));
                }
               
            }
            else
            {
                order = Model_SalesOrder.CreateOrder();
            }
            var obj = new
            {
                ID = order.ID,
                BillCode = order.BillCode,
                OrderDate = order.OrderDate,
                CustomerID = oc.BLLSession.ICustomerBLL.Entities.Where(c => c.ID == order.CustomerID).Select(c => new { ID = c.ID, Code = c.Code, Name = c.Name }).FirstOrDefault(),
                Remark = order.Remark
            };
           
            return Json(obj, JsonRequestBehavior.AllowGet);
        }  
        public ActionResult GetOrderDetail(string id)
        {
            int totalCount = 0;
            Guid mainID = Guid.Empty;
            
            if (Guid.TryParse(id,out mainID))
            {
                var objs = from detail in oc.BLLSession.ISalesOrderDetailBLL.Entities.Where(o => o.MainID.Equals(mainID))
                           join section in oc.BLLSession.ISectionbarBLL.Entities on detail.SectionbarID equals section.ID into d_s_join
                           from x in d_s_join.DefaultIfEmpty()
                           select new { ID = detail.ID, SectionbarID = detail.SectionbarID, SectionbarCode = x.Code, SectionbarName = x.Name };

                DataGrid dg = new DataGrid()
                {
                    total = totalCount,
                    rows = objs.ToList(),
                    footer = null
                };
                return Json(dg, JsonRequestBehavior.AllowGet);
            }
            return PackagingAjaxmsg(new AjaxMsgModel(AjaxStatu.err, "传入的参数有误！"));
        }

        

        /// <summary>
        /// 保存订单
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(string id)
        {
            var sr = new StreamReader(Request.InputStream);
            var str = sr.ReadToEnd();
            var objs = DataHelper.JsonToObject(str) as Dictionary<string,object>;
            List<object> detail = new List<object>();
            Guid ID = Guid.Empty;
            Guid.TryParse(id, out ID);
            SalesOrder order = oc.BLLSession.ISalesOrderBLL.Entities.FirstOrDefault(s => s.ID.Equals(ID));
            List<SalesOrderDetail> details = oc.BLLSession.ISalesOrderDetailBLL.Entities.Where(s=>s.MainID.Equals(ID)).ToList()??new List<SalesOrderDetail>();
            order = order ?? Model_SalesOrder.CreateOrder();
            var props= typeof(SalesOrder).GetProperties();
            var detailPropertys = typeof(SalesOrderDetail).GetProperties();
            foreach (var obj in objs)
            {
                if (obj.Value is object[])
                {
                    detail.AddRange(obj.Value as object[]);
                    continue;
                }
               // Console.WriteLine("列:{0}--值:{1}", obj.Key, obj.Value);
                var p = props.FirstOrDefault(o => o.Name == obj.Key);
                if (p!=null)
                {
                    
                    p.SetValue(order, p.PropertyType.ChangeType(obj.Value), null);
                    //p.SetValue(order, obj.Value, null);
                }
                
            }
            if (detail.Count>0)
            {
                details = new List<SalesOrderDetail>();
            }
            foreach (var o in detail)
            {
                
                var columns = o as Dictionary<string, object>;
                Guid detailID = Guid.Empty;
                if (columns.ContainsKey("ID"))
                {
                    Guid.TryParse(columns["ID"].ToString(), out detailID);
                }
                if (detailID.Equals(Guid.Empty))
                {
                    detailID = Guid.NewGuid();
                }
                SalesOrderDetail salesOrderDetail = details.FirstOrDefault(d => d.Equals(detailID));
                if (salesOrderDetail==null)
                {
                    salesOrderDetail = new SalesOrderDetail() { ID = detailID };
                    details.Add(salesOrderDetail);
                }
               
                salesOrderDetail.MainID = ID;
                foreach (var c in columns)
                {
                    Console.WriteLine("列:{0}--值:{1}", c.Key, c.Value);
                    var p = detailPropertys.FirstOrDefault(ps => ps.Name == c.Key);
                    if (p!=null)
                    {
                        p.SetValue(salesOrderDetail, p.PropertyType.ChangeType(c.Value), null);
                    }
                } 
            }
            oc.BLLSession.ISalesOrderBLL.Modify(order);
            return PackagingAjaxmsg(new AjaxMsgModel(AjaxStatu.ok, "保存成功！"));
        }


        #region 删除订单
        public ActionResult DeleteOrder(string id)
        {
            Guid ID = Guid.Empty;
            Guid.TryParse(id, out ID);
            var r = oc.BLLSession.ISalesOrderBLL.Del(o => o.ID.Equals(ID));
            return PackagingAjaxmsg(new AjaxMsgModel(AjaxStatu.ok, "成功删除" + r + "份订单!"));
        } 
        #endregion
    }
}