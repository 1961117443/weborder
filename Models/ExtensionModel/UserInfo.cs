using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public partial class UserInfo
    {
        /// <summary>
        /// 当前用户拥有的权限
        /// </summary>
        public List<SysModule> PermissionModule { get; set; }
    }
}
