using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebOrder.Areas
{
    public partial class Model_SysModule
    {
        #region 获取用户的权限

        public static List<SysModule> GetUserModule(UserInfo user)
        {
            List<SysModule> modules = null;
            //判断是否超级管理员
            if (user.UserName.Equals(AppMsg.SupperLoginUserName))
            {
                modules= OperContext.BLLSession.ISysModuleBLL.GetList(m=>!m.IsStop, m => m.OrderID);
            }
            else
            {
                modules = GetUserModule(user.ID);
            }
            OperContext.CurrentUser.PermissionModule = modules;
            return modules;
        }
        /// <summary>
        /// 根据用户ID得到对应的权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private static List<SysModule> GetUserModule(int userId)
        {
            //获取用户的角色
            List<int> roles = OperContext.BLLSession.ISysUserRoleBLL.Entities.Where(ur => ur.SysUserId == userId).Select(r => r.ID).ToList();
            //获取角色对应的权限
            List<int> moduleid = OperContext.BLLSession.ISysRoleModuleBLL.Entities.Where(rm => roles.Contains(rm.SysRoleId)).Select(m => m.SysModuleId).ToList();
            //获取用户特定的权限
            foreach (var item in OperContext.BLLSession.ISysUserModuleBLL.Entities.Where(um => um.SysUserId == userId))
            {
                moduleid.Add(item.SysModuleId);
            }
            List<SysModule> modules = OperContext.BLLSession.ISysModuleBLL.Entities.Where(m => !m.IsStop && moduleid.Contains(m.ID)).OrderBy(m => m.OrderID).ToList();
            
            return modules;
        } 
        #endregion

        /// <summary>
        /// 判断是否有权限
        /// </summary>
        /// <param name="area"></param>
        /// <param name="control"></param>
        /// <param name="action"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static bool ExistsPermission(string area,string control, string action, RequestMethod method)
        {
            if (OperContext.CurrentUser!=null && OperContext.CurrentUser.UserName.Equals(AppMsg.SupperLoginUserName))
            {
                return true;
            }
            if (OperContext.CurrentUser.PermissionModule==null || OperContext.CurrentUser.PermissionModule.Count==0)
            {
                return false;
            }
            return OperContext.CurrentUser.PermissionModule.Where(m => m.AreaName == area && m.ControlName == control && m.ActionName == action && m.FormMethod==(int)method).Count() > 0;
        }
      
    }
}