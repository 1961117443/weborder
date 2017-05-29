using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Common;

namespace Models
{
    public partial class SysModule
    {
        #region 把菜单转换成easyui的treenode
        /// <summary>
        /// 把菜单转换成easyui的treenode
        /// </summary>
        /// <returns></returns>
        private TreeNode ConvertTreeNode()
        {
            TreeNode tn = new TreeNode()
            {
                id = ID,
                text = Name,
                state = "open",// State ? "open" : "closed",
                attributes = new { url = GetUrl() },
                children = new List<TreeNode>()
            };
            return tn;
        }
        #endregion

        #region 根据数据库的记录，拼接url地址
        /// <summary>
        /// 根据数据库的记录，拼接url地址
        /// </summary>
        /// <returns></returns>
        private string GetUrl()
        {
            return StringHelper.FormatUrl(AreaName) + StringHelper.FormatUrl(ControlName) + StringHelper.FormatUrl(ActionName);
        }

        #endregion


        #region 根据用户的权限，返回TreeNode列表
        public static List<TreeNode> GetTreeNode(List<SysModule> modules)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            GetTreeNode(modules, nodes, 0);
            return nodes;
        }

        private static void GetTreeNode(List<SysModule> modules, List<TreeNode> nodes, int parentId)
        {
            foreach (var module in modules)
            {
                if (module.ParentID == parentId)
                {
                    TreeNode node = module.ConvertTreeNode();
                    nodes.Add(node);
                    GetTreeNode(modules, node.children, node.id);
                }
            }
        } 
        #endregion

    }
}
