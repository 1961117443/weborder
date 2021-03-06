﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Models
{
    /// <summary>
    /// Ajax请求返回的数据格式
    /// </summary>
    public class AjaxMsgModel
    {
        #region 属性
        public string Msg { get; set; }
        public AjaxStatu Statu { get; set; }
        public string BackUrl { get; set; }
        public object Data { get; set; } 
        #endregion 
        #region 构造函数
        public AjaxMsgModel(AjaxStatu statu, string msg, string url, object data)
        {
            Msg = msg;
            Statu = statu;
            BackUrl = url;
            Data = data;
        }

        public AjaxMsgModel(AjaxStatu statu, string msg, string url) : this(msg: msg, statu: statu, url: url, data: null)
        {

        }
        public AjaxMsgModel(AjaxStatu statu, string msg) : this(msg: msg, statu: statu, url: string.Empty)
        {

        }
        public AjaxMsgModel(AjaxStatu statu) : this(statu: statu, msg: string.Empty)
        {

        }

        public AjaxMsgModel()
        {

        }

        #endregion


    }
}
