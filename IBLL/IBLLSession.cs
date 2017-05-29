

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using Models;
namespace IBLL
{

public partial interface IBLLSession
{
	ICustomerBLL ICustomerBLL{get;set;}
	ILogBLL ILogBLL{get;set;}
	ISalesOrderBLL ISalesOrderBLL{get;set;}
	ISalesOrderDetailBLL ISalesOrderDetailBLL{get;set;}
	ISectionbarBLL ISectionbarBLL{get;set;}
	ISysDeptBLL ISysDeptBLL{get;set;}
	ISysModuleBLL ISysModuleBLL{get;set;}
	ISysRoleBLL ISysRoleBLL{get;set;}
	ISysRoleModuleBLL ISysRoleModuleBLL{get;set;}
	ISysUserModuleBLL ISysUserModuleBLL{get;set;}
	ISysUserRoleBLL ISysUserRoleBLL{get;set;}
	IUserInfoBLL IUserInfoBLL{get;set;}
}
}