﻿using Models;
using MvcWebOrder.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace MvcWebOrder.Areas.BasicData.Controllers
{
    public class SectionbarController : BaseController
    {
        // GET: BasicData/Sectionbar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowDetail()
        {
            int totalCount = 0;
            string code = string.Empty, name = string.Empty;
            if (Request["Code"]!=null)
            {
                code = Request["Code"];
            }
            if (Request["Name"] != null)
            {
                name = Request["Name"];
            }
            var list = oc.BLLSession.ISectionbarBLL.GetPageList(Page, Rows, ref totalCount, s => (s.Code == code || code == string.Empty) && (s.Name==name || name==string.Empty), s => s.Code, true);
            DataGrid dg = new DataGrid()
            {
                total = totalCount,
                rows = list,
                footer = new List<object>() { new { Code = "合计", Name = list.Count() } }
            };
            return Json(dg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSectionbar()
        {
            int totalCount = 0;
            var list = oc.BLLSession.ISectionbarBLL.Entities.Where(s=>1==1,Page,Rows,out totalCount,new PropertySortCondition("ID")).Select(s => new { ID = s.ID, Code = s.Code, Name = s.Name }).ToList();
            DataGrid dg = new DataGrid()
            {
                total = totalCount,
                rows = list,
                footer = null
            };
            return Json(dg, JsonRequestBehavior.AllowGet);
        }
    }
}