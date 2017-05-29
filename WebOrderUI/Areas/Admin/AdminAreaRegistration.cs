using System.Web.Mvc;

namespace MvcWebOrder.Areas
{
    public class AdminaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                AreaName + "_default",
               AreaName + "/{controller}/{action}/{id}",
                new { area = "Admin", controller = "AdminIndex", action = "Index", id = UrlParameter.Optional },
                new string[] { "MvcWebOrder.Areas."+AreaName+".Controllers" }
            );
        }
    }
}