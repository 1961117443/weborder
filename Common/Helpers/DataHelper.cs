using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
namespace Common
{
    public class DataHelper
    {
        static JavaScriptSerializer jss = new JavaScriptSerializer();
        #region JSON 与 OBJECT 转换
        public static string ObjectToJson(object obj)
        {
            return jss.Serialize(obj);
        }
        public static object JsonToObject(string json)
        {
            return jss.DeserializeObject(json);
        }
        public static T JsonToObject<T>(string json)
        {
            return jss.Deserialize<T>(json);
        }
        public static object JsonToObject(string json, Type t)
        {
            return jss.Deserialize(json, t);
        } 
        #endregion


         
    }
}
