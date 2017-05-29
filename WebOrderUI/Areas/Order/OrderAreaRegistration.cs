using System.Web.Mvc;

namespace MvcWebOrder.Areas
{
    public class OrderAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Order";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                AreaName+ "_default",
                AreaName + "/{controller}/{action}/{id}",
                new { area=AreaName,controller= "OrderIndex", action = "Index", id = UrlParameter.Optional },
                new string[] { "MvcWebOrder.Areas."+AreaName+".Controllers" }
            );
        }
    }
}