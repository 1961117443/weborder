using System.Web.Mvc;

namespace MvcWebOrder.Areas
{
    public class BasicDataAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BasicData";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                AreaName+ "_default",
                AreaName + "/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "MvcWebOrder.Areas." + AreaName + ".Controllers" }
            );
        }
    }
}