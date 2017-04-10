

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using Models;
namespace IDAL
{

public partial interface IDBSession
{
	ICustomerDAL ICustomerDAL{get;set;}
	ISectionbarDAL ISectionbarDAL{get;set;}
	ISysModuleDAL ISysModuleDAL{get;set;}
	IUserInfoDAL IUserInfoDAL{get;set;}
}
}