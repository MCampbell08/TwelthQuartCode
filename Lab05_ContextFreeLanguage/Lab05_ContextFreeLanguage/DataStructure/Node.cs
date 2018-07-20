using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05_ContextFreeLanguage.DataStructure
{
    public class Node
    {
        public Node Parent { get; set; }
        public List<Node> Nodes { get; set; }
        public object Value { get; set; }
    }
}
