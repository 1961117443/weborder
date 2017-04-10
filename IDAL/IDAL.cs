

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
public partial interface ISectionbarDAL:IBaseDAL<Sectionbar>
{
}
public partial interface ISysModuleDAL:IBaseDAL<SysModule>
{
}
public partial interface IUserInfoDAL:IBaseDAL<UserInfo>
{
}
}