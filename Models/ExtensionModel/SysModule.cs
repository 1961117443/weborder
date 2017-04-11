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
                state ="open",// State ? "open" : "closed",
                attributes = new { url = GetUrl() },
                children = new List<TreeNode>()
            };
            return tn;
        }

        private string GetUrl()
        {
            return StringHelper.FormatUrl(AreaName) + StringHelper.FormatUrl(ControlName) + StringHelper.FormatUrl(ActionName);
        }

        public static List<TreeNode> GetTreeNode(List<SysModule> modules)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            GetTreeNode(modules, nodes, 0);
            return nodes;
        }

        private static void GetTreeNode(List<SysModule> modules,List<TreeNode> nodes,int parentId)
        {
            foreach (var module in modules)
            {
                if (module.ParentID==parentId)
                {
                    TreeNode node = module.ConvertTreeNode();
                    nodes.Add(node);
                    GetTreeNode(modules, node.children, node.id);
                }
            } 
        }

    }
}
