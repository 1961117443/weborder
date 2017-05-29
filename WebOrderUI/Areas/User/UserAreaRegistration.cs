using System.Web.Mvc;

namespace MvcWebOrder.Areas
{
    public class UserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "User";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                AreaName+"_default",
                AreaName + "/{controller}/{action}/{id}",
                new { area= AreaName, action = "Index", controller= "UserIndex", id = UrlParameter.Optional },
                new string[] { "MvcWebOrder.Areas."+ AreaName + ".Controllers" }
            );
        }
    }
}