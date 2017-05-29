

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using Models;
using IDAL;
namespace DALMsSql
{
public partial class CustomerDAL:BaseDAL<Customer>,ICustomerDAL
{
}
public partial class LogDAL:BaseDAL<Log>,ILogDAL
{
}
public partial class SalesOrderDAL:BaseDAL<SalesOrder>,ISalesOrderDAL
{
}
public partial class SalesOrderDetailDAL:BaseDAL<SalesOrderDetail>,ISalesOrderDetailDAL
{
}
public partial class SectionbarDAL:BaseDAL<Sectionbar>,ISectionbarDAL
{
}
public partial class SysDeptDAL:BaseDAL<SysDept>,ISysDeptDAL
{
}
public partial class SysModuleDAL:BaseDAL<SysModule>,ISysModuleDAL
{
}
public partial class SysRoleDAL:BaseDAL<SysRole>,ISysRoleDAL
{
}
public partial class SysRoleModuleDAL:BaseDAL<SysRoleModule>,ISysRoleModuleDAL
{
}
public partial class SysUserModuleDAL:BaseDAL<SysUserModule>,ISysUserModuleDAL
{
}
public partial class SysUserRoleDAL:BaseDAL<SysUserRole>,ISysUserRoleDAL
{
}
public partial class UserInfoDAL:BaseDAL<UserInfo>,IUserInfoDAL
{
}
}