using System.Web.Mvc;
using Models;
using Common;
namespace MvcWebOrder.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
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
                return oc.PackagingAjaxMsg(AjaxStatu.ok, "登录成功", null, "/Admin/Index");
            }
            else
            {
                return oc.PackagingAjaxMsg(AjaxStatu.err, "登录失败", null, "");
            }

        }
    }
}