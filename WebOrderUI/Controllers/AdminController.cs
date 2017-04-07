using System.Web.Mvc;
using Models;
namespace MvcWebOrder.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            // Old
            //OperContext oc = new OperContext(); 
            OperContext oc = OperContext.CurrentOperContext;
            var lis = oc.BLLSession.IUserInfoBLL.GetList();
            return Content(lis.Count.ToString());
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginIn()
        {

            string userName = Request["name"];
            string passWord = Request["pwd"];

            OperContext oc = OperContext.CurrentOperContext;

            var user = oc.BLLSession.IUserInfoBLL.Login(userName, passWord);

            if (user != null)
            {
                //把登录信息保存到session中
                Session["loginUser"] = user;
                //保存cookie
                //返回ajax信息
                return oc.PackagingAjaxMsg("ok", "登录成功", null, "/Admin/Index");
            }
            else
            {
                return oc.PackagingAjaxMsg("err", "登录失败", null, "");
            }

        }
    }
}