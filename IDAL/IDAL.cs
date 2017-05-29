

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using Models;
namespace IDAL
{
public partial interface ICustomerDAL:IBaseDAL<Customer>
{
}
public partial interface ILogDAL:IBaseDAL<Log>
{
}
public partial interface ISalesOrderDAL:IBaseDAL<SalesOrder>
{
}
public partial interface ISalesOrderDetailDAL:IBaseDAL<SalesOrderDetail>
{
}
public partial interface ISectionbarDAL:IBaseDAL<Sectionbar>
{
}
public partial interface ISysDeptDAL:IBaseDAL<SysDept>
{
}
public partial interface ISysModuleDAL:IBaseDAL<SysModule>
{
}
public partial interface ISysRoleDAL:IBaseDAL<SysRole>
{
}
public partial interface ISysRoleModuleDAL:IBaseDAL<SysRoleModule>
{
}
public partial interface ISysUserModuleDAL:IBaseDAL<SysUserModule>
{
}
public partial interface ISysUserRoleDAL:IBaseDAL<SysUserRole>
{
}
public partial interface IUserInfoDAL:IBaseDAL<UserInfo>
{
}
}