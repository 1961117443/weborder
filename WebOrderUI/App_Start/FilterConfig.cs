using MvcWebOrder.Areas.Filters;
using System.Web;
using System.Web.Mvc;

namespace MvcWebOrder
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //注册过滤器
            filters.Add(new LoginValidateAttribute());
        }
    }
}
