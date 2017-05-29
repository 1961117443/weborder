using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 全局常量
    /// </summary>
    public class AppMsg
    {
        #region 
        /// <summary>
        /// 验证码的Session名称
        /// </summary>
        public const string Session_ValidateCode = "Session_ValidateCode";
        /// <summary>
        /// 当前用户信息
        /// </summary>
        public const string Session_CurrentUser = "Session_CurrentUser";
        /// <summary>
        /// 保存当前用户信息的CookieID
        /// </summary>
        public const string Admin_Cookie_UserLoginName = "Cookie_Login_Name";
        /// <summary>
        /// 保存当前用户ID的CookieID
        /// </summary>
        public const string Admin_Cookie_UserLoginID = "Cookie_Login_ID";
        /// <summary>
        /// cookie所存储的位置
        /// </summary>
        public const string Admin_Cookie_Path = "/admin/";
        #endregion


        #region 提示信息
        public const string LoginFail = "登录失败";
        public const string LoginSuccess = "登录成功";
        #endregion

        /// <summary>
        /// 超级用户
        /// </summary>
        public const string SupperLoginUserName = "admin";
    }
}
