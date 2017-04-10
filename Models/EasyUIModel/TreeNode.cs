using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    ///id：节点ID，对加载远程数据很重要。
    ///text：显示节点文本。
    ///state：节点状态，'open' 或 'closed'，默认：'open'。如果为'closed'的时候，将不自动展开该节点。
    ///checked：表示该节点是否被选中。
    ///attributes: 被添加到节点的自定义属性。
    ///children: 一个节点数组声明了若干节点。 
    /// </summary>
    public class TreeNode
    {
        public int id { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public object attributes { get; set; }
        public List<TreeNode> children { get; set; }
    }
}
