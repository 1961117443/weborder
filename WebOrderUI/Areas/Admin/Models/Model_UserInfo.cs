using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebOrder.Areas
{
    public partial class Model_UserInfo
    {

        #region 生成验证码
        public static byte[] GenerateValidateCode(int length = 4)
        {
            ValidateCode vc = new ValidateCode();
            string code = vc.CreateValidateCode(length);
            OperContext.CurrentUserValidateCode = code;
            return vc.CreateValidateGraphic(code);
        }
        #endregion

        #region 登录
        public static AjaxMsgModel LoginIn(string userName, string passWord, string validateCode)
        {
            if (!validateCode.Equals(OperContext.CurrentUserValidateCode))
            {
                return new AjaxMsgModel(AjaxStatu.err, AppMsg.LoginFail);
            }
            var users = OperContext.BLLSession.IUserInfoBLL.Entities.Where(u => u.UserName == userName).ToList();
            if (users.Count > 0)
            {
                bool b = false;
                foreach (var user in users)
                {
                    if (user.PassWord.Equals(passWord))
                    {
                        user.LoginTime = DateTime.Now;
                        if (OperContext.BLLSession.IUserInfoBLL.Modify(user, "LoginTime") > 0)
                        {
                            OperContext.CurrentUser = user;
                            OperContext.CurrentLoginName = user.UserName;
                            /*获取权限*/
                            Model_SysModule.GetUserModule(user);
                            b = true;
                        }
                        break;
                    }
                }
                return b ? new AjaxMsgModel(AjaxStatu.ok, AppMsg.LoginSuccess, "/Admin/AdminIndex/Index") : new AjaxMsgModel(AjaxStatu.err, AppMsg.LoginFail + "密码错误！");
            }

            return new AjaxMsgModel(AjaxStatu.err, AppMsg.LoginFail + "用户不存在！");

        }
        #endregion

        /// <summary>
        /// 判断当前用户是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            if (OperContext.CurrentUser==null)
            {
                if (OperContext.CurrentLoginUserID!=null)
                {
                    int id = -1;
                    if (int.TryParse(OperContext.CurrentLoginUserID, out id))
                    {
                        var user = OperContext.BLLSession.IUserInfoBLL.Entities.Where(u => u.ID == id).FirstOrDefault();
                        if (user!=null)
                        {
                            OperContext.CurrentUser = user;
                            return true;
                        }
                    }                    
                     
                }
                return false;
            }
            return true;
        }
    }
}