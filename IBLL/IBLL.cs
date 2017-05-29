

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using Models;
namespace IBLL
{
public partial interface ICustomerBLL:IBaseBLL<Customer>
{
}
public partial interface ILogBLL:IBaseBLL<Log>
{
}
public partial interface ISalesOrderBLL:IBaseBLL<SalesOrder>
{
}
public partial interface ISalesOrderDetailBLL:IBaseBLL<SalesOrderDetail>
{
}
public partial interface ISectionbarBLL:IBaseBLL<Sectionbar>
{
}
public partial interface ISysDeptBLL:IBaseBLL<SysDept>
{
}
public partial interface ISysModuleBLL:IBaseBLL<SysModule>
{
}
public partial interface ISysRoleBLL:IBaseBLL<SysRole>
{
}
public partial interface ISysRoleModuleBLL:IBaseBLL<SysRoleModule>
{
}
public partial interface ISysUserModuleBLL:IBaseBLL<SysUserModule>
{
}
public partial interface ISysUserRoleBLL:IBaseBLL<SysUserRole>
{
}
public partial interface IUserInfoBLL:IBaseBLL<UserInfo>
{
}
}