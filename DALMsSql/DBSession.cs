

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using Models;
using IDAL;
namespace DALMsSql
{

public partial class DBSession:IDBSession
{

   #region 01 数据接口 ICustomerDAL
   ICustomerDAL _CustomerDAL;
   public ICustomerDAL ICustomerDAL
   {
		get
		{
			if(_CustomerDAL==null)
			{
				_CustomerDAL = new CustomerDAL();
			}
			return _CustomerDAL;
		}
		set
		{
			_CustomerDAL = value;
		}
   }
   #endregion
	
   #region 02 数据接口 ILogDAL
   ILogDAL _LogDAL;
   public ILogDAL ILogDAL
   {
		get
		{
			if(_LogDAL==null)
			{
				_LogDAL = new LogDAL();
			}
			return _LogDAL;
		}
		set
		{
			_LogDAL = value;
		}
   }
   #endregion
	
   #region 03 数据接口 ISalesOrderDAL
   ISalesOrderDAL _SalesOrderDAL;
   public ISalesOrderDAL ISalesOrderDAL
   {
		get
		{
			if(_SalesOrderDAL==null)
			{
				_SalesOrderDAL = new SalesOrderDAL();
			}
			return _SalesOrderDAL;
		}
		set
		{
			_SalesOrderDAL = value;
		}
   }
   #endregion
	
   #region 04 数据接口 ISalesOrderDetailDAL
   ISalesOrderDetailDAL _SalesOrderDetailDAL;
   public ISalesOrderDetailDAL ISalesOrderDetailDAL
   {
		get
		{
			if(_SalesOrderDetailDAL==null)
			{
				_SalesOrderDetailDAL = new SalesOrderDetailDAL();
			}
			return _SalesOrderDetailDAL;
		}
		set
		{
			_SalesOrderDetailDAL = value;
		}
   }
   #endregion
	
   #region 05 数据接口 ISectionbarDAL
   ISectionbarDAL _SectionbarDAL;
   public ISectionbarDAL ISectionbarDAL
   {
		get
		{
			if(_SectionbarDAL==null)
			{
				_SectionbarDAL = new SectionbarDAL();
			}
			return _SectionbarDAL;
		}
		set
		{
			_SectionbarDAL = value;
		}
   }
   #endregion
	
   #region 06 数据接口 ISysDeptDAL
   ISysDeptDAL _SysDeptDAL;
   public ISysDeptDAL ISysDeptDAL
   {
		get
		{
			if(_SysDeptDAL==null)
			{
				_SysDeptDAL = new SysDeptDAL();
			}
			return _SysDeptDAL;
		}
		set
		{
			_SysDeptDAL = value;
		}
   }
   #endregion
	
   #region 07 数据接口 ISysModuleDAL
   ISysModuleDAL _SysModuleDAL;
   public ISysModuleDAL ISysModuleDAL
   {
		get
		{
			if(_SysModuleDAL==null)
			{
				_SysModuleDAL = new SysModuleDAL();
			}
			return _SysModuleDAL;
		}
		set
		{
			_SysModuleDAL = value;
		}
   }
   #endregion
	
   #region 08 数据接口 ISysRoleDAL
   ISysRoleDAL _SysRoleDAL;
   public ISysRoleDAL ISysRoleDAL
   {
		get
		{
			if(_SysRoleDAL==null)
			{
				_SysRoleDAL = new SysRoleDAL();
			}
			return _SysRoleDAL;
		}
		set
		{
			_SysRoleDAL = value;
		}
   }
   #endregion
	
   #region 09 数据接口 ISysRoleModuleDAL
   ISysRoleModuleDAL _SysRoleModuleDAL;
   public ISysRoleModuleDAL ISysRoleModuleDAL
   {
		get
		{
			if(_SysRoleModuleDAL==null)
			{
				_SysRoleModuleDAL = new SysRoleModuleDAL();
			}
			return _SysRoleModuleDAL;
		}
		set
		{
			_SysRoleModuleDAL = value;
		}
   }
   #endregion
	
   #region 10 数据接口 ISysUserModuleDAL
   ISysUserModuleDAL _SysUserModuleDAL;
   public ISysUserModuleDAL ISysUserModuleDAL
   {
		get
		{
			if(_SysUserModuleDAL==null)
			{
				_SysUserModuleDAL = new SysUserModuleDAL();
			}
			return _SysUserModuleDAL;
		}
		set
		{
			_SysUserModuleDAL = value;
		}
   }
   #endregion
	
   #region 11 数据接口 ISysUserRoleDAL
   ISysUserRoleDAL _SysUserRoleDAL;
   public ISysUserRoleDAL ISysUserRoleDAL
   {
		get
		{
			if(_SysUserRoleDAL==null)
			{
				_SysUserRoleDAL = new SysUserRoleDAL();
			}
			return _SysUserRoleDAL;
		}
		set
		{
			_SysUserRoleDAL = value;
		}
   }
   #endregion
	
   #region 12 数据接口 IUserInfoDAL
   IUserInfoDAL _UserInfoDAL;
   public IUserInfoDAL IUserInfoDAL
   {
		get
		{
			if(_UserInfoDAL==null)
			{
				_UserInfoDAL = new UserInfoDAL();
			}
			return _UserInfoDAL;
		}
		set
		{
			_UserInfoDAL = value;
		}
   }
   #endregion
	
}
}