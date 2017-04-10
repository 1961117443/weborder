

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
	
   #region 02 数据接口 ISectionbarBLL
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
	
   #region 03 数据接口 ISysModuleBLL
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
	
   #region 04 数据接口 IUserInfoBLL
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