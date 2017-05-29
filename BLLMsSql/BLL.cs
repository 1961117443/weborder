

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using Models;
using IBLL; 
namespace BLLMsSql
{
public partial class CustomerBLL:BaseBLL<Customer>,ICustomerBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ICustomerDAL;
    }
}
public partial class LogBLL:BaseBLL<Log>,ILogBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ILogDAL;
    }
}
public partial class SalesOrderBLL:BaseBLL<SalesOrder>,ISalesOrderBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ISalesOrderDAL;
    }
}
public partial class SalesOrderDetailBLL:BaseBLL<SalesOrderDetail>,ISalesOrderDetailBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ISalesOrderDetailDAL;
    }
}
public partial class SectionbarBLL:BaseBLL<Sectionbar>,ISectionbarBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ISectionbarDAL;
    }
}
public partial class SysDeptBLL:BaseBLL<SysDept>,ISysDeptBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ISysDeptDAL;
    }
}
public partial class SysModuleBLL:BaseBLL<SysModule>,ISysModuleBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ISysModuleDAL;
    }
}
public partial class SysRoleBLL:BaseBLL<SysRole>,ISysRoleBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ISysRoleDAL;
    }
}
public partial class SysRoleModuleBLL:BaseBLL<SysRoleModule>,ISysRoleModuleBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ISysRoleModuleDAL;
    }
}
public partial class SysUserModuleBLL:BaseBLL<SysUserModule>,ISysUserModuleBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ISysUserModuleDAL;
    }
}
public partial class SysUserRoleBLL:BaseBLL<SysUserRole>,ISysUserRoleBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ISysUserRoleDAL;
    }
}
public partial class UserInfoBLL:BaseBLL<UserInfo>,IUserInfoBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.IUserInfoDAL;
    }
}
}