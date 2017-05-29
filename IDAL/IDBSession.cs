

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using Models;
namespace IDAL
{

public partial interface IDBSession
{
	ICustomerDAL ICustomerDAL{get;set;}
	ILogDAL ILogDAL{get;set;}
	ISalesOrderDAL ISalesOrderDAL{get;set;}
	ISalesOrderDetailDAL ISalesOrderDetailDAL{get;set;}
	ISectionbarDAL ISectionbarDAL{get;set;}
	ISysDeptDAL ISysDeptDAL{get;set;}
	ISysModuleDAL ISysModuleDAL{get;set;}
	ISysRoleDAL ISysRoleDAL{get;set;}
	ISysRoleModuleDAL ISysRoleModuleDAL{get;set;}
	ISysUserModuleDAL ISysUserModuleDAL{get;set;}
	ISysUserRoleDAL ISysUserRoleDAL{get;set;}
	IUserInfoDAL IUserInfoDAL{get;set;}
}
}