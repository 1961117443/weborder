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
                name: AreaName + "_default",
               url: AreaName + "/{controller}/{action}/{id}",
               defaults: new { area = AreaName, controller = "OrderIndex", action = "Index", id = UrlParameter.Optional },
               // constraints: new { id = @"^\d*$" },
              namespaces: new string[] { "MvcWebOrder.Areas." + AreaName + ".Controllers" }
            );
        }
    }
}