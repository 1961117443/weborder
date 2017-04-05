

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
public partial class SectionbarBLL:BaseBLL<Sectionbar>,ISectionbarBLL
{
	public override void SetDAL()
    {
		iDAL= DBSession.ISectionbarDAL;
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