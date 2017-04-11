using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class StringHelper
    {
        /// <summary>
        /// 组合地址，如果传进来的参数不为空，在参数前面加上 /
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string FormatUrl(string name)
        {
            return string.IsNullOrEmpty(name) ? "" : "/" + name;
        }
    }
}
