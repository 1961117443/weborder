

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
	
   #region 02 数据接口 ISectionbarDAL
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
	
   #region 03 数据接口 ISysModuleDAL
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
	
   #region 04 数据接口 IUserInfoDAL
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