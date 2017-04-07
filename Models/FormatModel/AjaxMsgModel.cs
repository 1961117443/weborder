using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class AjaxMsgModel
    {
        public string Msg { get; set; }
        public string Statu { get; set; }
        public string BackUrl { get; set; }
        public object Data { get; set; }
    }
}
