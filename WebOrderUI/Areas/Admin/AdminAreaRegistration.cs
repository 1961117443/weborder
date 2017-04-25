using System.Web.Mvc;

namespace MvcWebOrder.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
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
               AreaName+  "_default",
                AreaName + "/{controller}/{action}/{id}",
                new { area=AreaName,controller= "AdminIndex", action = "Index", id = UrlParameter.Optional },
                new string[] { "MvcWebOrder.Areas"+AreaName+ ".Controller" }
            );
        }
    }
}