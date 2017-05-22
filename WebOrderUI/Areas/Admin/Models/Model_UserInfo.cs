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

        public static AjaxMsgModel LoginIn(string userName,string passWord,string validateCode)
        {
            if (!validateCode.Equals(OperContext.CurrentUserValidateCode))
            {
                return new AjaxMsgModel(AjaxStatu.err, AppMsg.LoginFail);
            }
            var users = OperContext.BLLSession.IUserInfoBLL.Entities.Where(u => u.UserName == userName).ToList();
            if (users.Count>0)
            {
                bool b = false;
                foreach (var user in users)
                {
                    if (user.PassWord.Equals(passWord))
                    {
                        OperContext.CurrentUser = user;
                        b = true;
                        break;
                    }
                }
                return b ? new AjaxMsgModel(AjaxStatu.ok, AppMsg.LoginSuccess, "/User/UserIndex") : new AjaxMsgModel(AjaxStatu.err, AppMsg.LoginFail+"密码错误！");
            }

            return  new AjaxMsgModel(AjaxStatu.err, AppMsg.LoginFail + "用户不存在！");

        }
    }
}