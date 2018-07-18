using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05_ContextFreeLanguage.DataStructure
{
    public class Node
    {
        public Node Parent { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public object Value { get; set; }
        public bool IsEmpty { get; set; }
    }
}
