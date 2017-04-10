

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using Models;
namespace IBLL
{

public partial interface IBLLSession
{
	ICustomerBLL ICustomerBLL{get;set;}
	ISectionbarBLL ISectionbarBLL{get;set;}
	ISysModuleBLL ISysModuleBLL{get;set;}
	IUserInfoBLL IUserInfoBLL{get;set;}
}
}