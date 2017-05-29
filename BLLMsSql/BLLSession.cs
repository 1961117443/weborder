

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using Models;
using IBLL;
namespace BLLMsSql
{

public partial class BLLSession:IBLLSession
{

   #region 01 数据接口 ICustomerBLL
   ICustomerBLL _CustomerBLL;
   public ICustomerBLL ICustomerBLL
   {
		get
		{
			if(_CustomerBLL==null)
			{
				_CustomerBLL = new CustomerBLL();
			}
			return _CustomerBLL;
		}
		set
		{
			_CustomerBLL = value;
		}
   }
   #endregion
	
   #region 02 数据接口 ILogBLL
   ILogBLL _LogBLL;
   public ILogBLL ILogBLL
   {
		get
		{
			if(_LogBLL==null)
			{
				_LogBLL = new LogBLL();
			}
			return _LogBLL;
		}
		set
		{
			_LogBLL = value;
		}
   }
   #endregion
	
   #region 03 数据接口 ISalesOrderBLL
   ISalesOrderBLL _SalesOrderBLL;
   public ISalesOrderBLL ISalesOrderBLL
   {
		get
		{
			if(_SalesOrderBLL==null)
			{
				_SalesOrderBLL = new SalesOrderBLL();
			}
			return _SalesOrderBLL;
		}
		set
		{
			_SalesOrderBLL = value;
		}
   }
   #endregion
	
   #region 04 数据接口 ISalesOrderDetailBLL
   ISalesOrderDetailBLL _SalesOrderDetailBLL;
   public ISalesOrderDetailBLL ISalesOrderDetailBLL
   {
		get
		{
			if(_SalesOrderDetailBLL==null)
			{
				_SalesOrderDetailBLL = new SalesOrderDetailBLL();
			}
			return _SalesOrderDetailBLL;
		}
		set
		{
			_SalesOrderDetailBLL = value;
		}
   }
   #endregion
	
   #region 05 数据接口 ISectionbarBLL
   ISectionbarBLL _SectionbarBLL;
   public ISectionbarBLL ISectionbarBLL
   {
		get
		{
			if(_SectionbarBLL==null)
			{
				_SectionbarBLL = new SectionbarBLL();
			}
			return _SectionbarBLL;
		}
		set
		{
			_SectionbarBLL = value;
		}
   }
   #endregion
	
   #region 06 数据接口 ISysDeptBLL
   ISysDeptBLL _SysDeptBLL;
   public ISysDeptBLL ISysDeptBLL
   {
		get
		{
			if(_SysDeptBLL==null)
			{
				_SysDeptBLL = new SysDeptBLL();
			}
			return _SysDeptBLL;
		}
		set
		{
			_SysDeptBLL = value;
		}
   }
   #endregion
	
   #region 07 数据接口 ISysModuleBLL
   ISysModuleBLL _SysModuleBLL;
   public ISysModuleBLL ISysModuleBLL
   {
		get
		{
			if(_SysModuleBLL==null)
			{
				_SysModuleBLL = new SysModuleBLL();
			}
			return _SysModuleBLL;
		}
		set
		{
			_SysModuleBLL = value;
		}
   }
   #endregion
	
   #region 08 数据接口 ISysRoleBLL
   ISysRoleBLL _SysRoleBLL;
   public ISysRoleBLL ISysRoleBLL
   {
		get
		{
			if(_SysRoleBLL==null)
			{
				_SysRoleBLL = new SysRoleBLL();
			}
			return _SysRoleBLL;
		}
		set
		{
			_SysRoleBLL = value;
		}
   }
   #endregion
	
   #region 09 数据接口 ISysRoleModuleBLL
   ISysRoleModuleBLL _SysRoleModuleBLL;
   public ISysRoleModuleBLL ISysRoleModuleBLL
   {
		get
		{
			if(_SysRoleModuleBLL==null)
			{
				_SysRoleModuleBLL = new SysRoleModuleBLL();
			}
			return _SysRoleModuleBLL;
		}
		set
		{
			_SysRoleModuleBLL = value;
		}
   }
   #endregion
	
   #region 10 数据接口 ISysUserModuleBLL
   ISysUserModuleBLL _SysUserModuleBLL;
   public ISysUserModuleBLL ISysUserModuleBLL
   {
		get
		{
			if(_SysUserModuleBLL==null)
			{
				_SysUserModuleBLL = new SysUserModuleBLL();
			}
			return _SysUserModuleBLL;
		}
		set
		{
			_SysUserModuleBLL = value;
		}
   }
   #endregion
	
   #region 11 数据接口 ISysUserRoleBLL
   ISysUserRoleBLL _SysUserRoleBLL;
   public ISysUserRoleBLL ISysUserRoleBLL
   {
		get
		{
			if(_SysUserRoleBLL==null)
			{
				_SysUserRoleBLL = new SysUserRoleBLL();
			}
			return _SysUserRoleBLL;
		}
		set
		{
			_SysUserRoleBLL = value;
		}
   }
   #endregion
	
   #region 12 数据接口 IUserInfoBLL
   IUserInfoBLL _UserInfoBLL;
   public IUserInfoBLL IUserInfoBLL
   {
		get
		{
			if(_UserInfoBLL==null)
			{
				_UserInfoBLL = new UserInfoBLL();
			}
			return _UserInfoBLL;
		}
		set
		{
			_UserInfoBLL = value;
		}
   }
   #endregion
	
}
}