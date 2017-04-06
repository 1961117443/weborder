using System.Web.Mvc;
using Models;
namespace MvcWebOrder.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            OperContext oc = new OperContext();
            var lis= oc.BLLSession.IUserInfoBLL.GetList();
            return Content(lis.Count.ToString());
        }
    }
}