using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBLL;
using Models;

namespace BLLMsSql
{
    public partial class UserInfoBLL:IUserInfoBLL
    {
        public UserInfo Login(string userName,string passWord)
        { 
            var user = GetList(u => u.UserName == userName).FirstOrDefault();
            if (user!=null && user.PassWord.Equals(passWord))
            {
                return user;
            }
            return null;
        }
    }
}
