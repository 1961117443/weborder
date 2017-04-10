

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
public partial class SectionbarDAL:BaseDAL<Sectionbar>,ISectionbarDAL
{
}
public partial class SysModuleDAL:BaseDAL<SysModule>,ISysModuleDAL
{
}
public partial class UserInfoDAL:BaseDAL<UserInfo>,IUserInfoDAL
{
}
}