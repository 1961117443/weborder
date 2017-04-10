

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
public partial interface ISectionbarBLL:IBaseBLL<Sectionbar>
{
}
public partial interface ISysModuleBLL:IBaseBLL<SysModule>
{
}
public partial interface IUserInfoBLL:IBaseBLL<UserInfo>
{
}
}